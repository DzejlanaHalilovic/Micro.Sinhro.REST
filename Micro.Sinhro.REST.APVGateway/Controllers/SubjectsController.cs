using Micro.Sinhro.REST.APIGateway.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Micro.Sinhro.REST.APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly HttpClient httpClient;
        private readonly Urls urls;

        public SubjectsController(HttpClient httpClient, IOptions<Urls> urls)
        {
            this.httpClient = httpClient;
            this.urls = urls.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = httpClient.GetAsync(urls.Subjects + "/predmeti").Result;

            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            var student = JsonConvert.DeserializeObject<List<Predmet>>(content);
            return Ok(student);
        }

    }
}
