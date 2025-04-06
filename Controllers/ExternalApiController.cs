using Microsoft.AspNetCore.Mvc;
using WebApplication5.Services;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalApiController : ControllerBase
    {
        private readonly ExternalApiService _externalApiService;

        public ExternalApiController(ExternalApiService externalApiService)
        {
            _externalApiService = externalApiService;
        }

        // Example GET method to get data from an external API
        [HttpGet("data")]
        public async Task<ActionResult<string>> GetExternalData()
        {
            string url = "https://jsonplaceholder.typicode.com/posts";
            var data = await _externalApiService.GetExternalDataAsync(url);
            return Ok(data);
        }

        // You can add other endpoints to interact with external APIs as needed
        [HttpGet("other-data")]
        public async Task<ActionResult<string>> GetOtherData()
        {
            string url = "https://api.example.com/otherdata"; // replace with the actual external API URL
            var data = await _externalApiService.GetExternalDataAsync(url);
            return Ok(data);
        }
    }
}
