using Micro.Sinhro.REST.APIGateway.Models;
using Micro.Sinhro.REST.APIGateway.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Micro.Sinhro.REST.APIGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : Controller
    {

        private readonly HttpClient httpClient;
        private readonly Urls urls;
        public StudentsController(HttpClient httpClient, IOptions<Urls>url)
        {
            this.httpClient = httpClient;
            this.urls = url.Value;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //TODO :implement endpoint by calling the microservice Student
            var response = httpClient.GetAsync(urls.Students + "/Students").Result;
            
            // pomocu ove dole metode se proverava da l je sve proslo kako treba
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            var student = JsonConvert.DeserializeObject<List<Student>>(content);
            return Ok(student);
        }

        // da imamo servis da dodamo ocenu 


        

    }
}
