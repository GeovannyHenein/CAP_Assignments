using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortner.Controllers
{
    [Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},BasicAuthentication")]
    [ApiController]
    [Route("[controller]")]
    public class ShortUrlsController : ControllerBase
    {
        [Authorize(Policy = "AddCustomer")]
        [HttpPut("{id}")]
        public IActionResult CreateShortUrl(string id, [FromBody] JsonElement body)
        {
            Console.WriteLine($"Request to create: {id}, {body.GetProperty("url")}");
            return Ok("https://shortUrl.com");
        }

        [Authorize(Roles = "Emperor,Deacon")]
        [HttpDelete("{id}")]
        public IActionResult DeleteShortUrl(string id)
        {
            Console.WriteLine($"Request to delete: {id}");
            return Ok("deleted!");
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetShortUrl(string id)
        {
            Console.WriteLine($"Request to get: {id}");
            return Ok("shortUrl");
        }

        [HttpGet]
        public IActionResult List()
        {
            Console.WriteLine("Request to list");
            var urls = new List<string> { "url1", "url2" };
            return Ok(urls);
        }
    }
}
