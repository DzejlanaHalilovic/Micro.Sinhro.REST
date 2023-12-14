using Micro.Sinhro.REST.APIGateway.Persistance;
using Micro.Sinhro.REST.Student.Persistance;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Micro.Sinhro.REST.Student.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : Controller
    {
        private readonly StudentDbContext context;
        private readonly IMessageBroker broker;

        public StudentsController(StudentDbContext context, IMessageBroker broker)
        {
            this.context = context;
            this.broker = broker;
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
        [HttpGet("pickGrades")]
        public IActionResult PickGrades()
        {
            var result = broker.Consume();
            var grades = JsonConvert.DeserializeObject<Models.Grade[]>(result);
            foreach (var g in grades)
            {
                var student = context.Students.FirstOrDefault(s => s.Id == g.StudentId);
                if(student.numGrades.HasValue)
                {
                     var sum = student.numGrades * student.avgGrade;
                    student.numGrades++;
                    sum += g.Value;
                    student.avgGrade = sum / student.numGrades;

                }
                else
                {
                    student.numGrades = 1;
                    student.avgGrade = g.Value;
                }
            }
            return Ok("Updates" + grades.Count());
        }



    }
}
