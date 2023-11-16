using Micro.Sinhro.REST.Student.Persistance;
using Microsoft.AspNetCore.Mvc;

namespace Micro.Sinhro.REST.Student.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : Controller
    {
        private readonly StudentDbContext context;
        public StudentsController(StudentDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var student = context.Students.ToList();
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Models.Student student)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Students.Add(student);
            context.SaveChanges();
            return Ok(student);
        }
       



    }
}
