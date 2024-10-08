using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortner.Controllers
{
    [Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},BasicAuthentication")]
    [ApiController]
    [Route("[controller]")]
    public class NavigateController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("{shortUrl}")]
        public IActionResult Navigate(string shortUrl)
        {
            Console.WriteLine($"Request to navigate for {shortUrl}");
            return Redirect("https://www.google.com");
        }
    }
}
