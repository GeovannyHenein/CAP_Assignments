using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using UrlShortner.Helper;
using UrlShortner.Models;

namespace UrlShortner.Security;

public class BasicAuthenticationHandler(
    IOptionsMonitor<AuthenticationSchemeOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder) : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
{
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        try
        {
            // The API will receive Basic username:password in Base 64. Decode it
            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers.Authorization!);
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter!);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
            var email = credentials[0];
            var password = credentials[1];

            // Get the user by email
            var user = DataMock.GetUserByEmail(email);

            if (user != null && VerifyPassword(password, user.Password, user.PasswordSalt))
            {
                // C# middleware captures the email which will be used later by authorization via ClaimsTransformer
                var claims = new[] { new Claim("emails", email) };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
            else
            {
                return AuthenticateResult.Fail("Invalid Username or Password");
            }
        }
        catch
        {
            return AuthenticateResult.Fail("Invalid Authorization Header");
        }
    }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

    private bool VerifyPassword(string enteredPassword, string storedHashedPassword, string salt)
    {
        using var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(salt));
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(enteredPassword));
        return computedHash.SequenceEqual(Convert.FromBase64String(storedHashedPassword));
    }
}
