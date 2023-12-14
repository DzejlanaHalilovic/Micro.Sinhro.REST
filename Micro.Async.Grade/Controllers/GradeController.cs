using Micro.Async.Grade.DTOs;
using Micro.Async.Grade.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Micro.Async.Grade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {

        private readonly GradeDBContext context;
        private readonly IMessageBroker messageBroker;

        public GradeController(GradeDBContext context, IMessageBroker messageBroker)
        {
            this.context = context;
            this.messageBroker = messageBroker;
        }
        [HttpPost]
        public IActionResult Post([FromBody] GradeDTO grade)
        {

            // implement logic to save grade to database
            var newGrade = new Models.Grade
            {
                StudentId = grade.StudentId,
                CourseId = grade.CourseId,
                Value = grade.Value,
                Date = grade.Date
            };
            context.Grades.Add(newGrade);
            context.SaveChanges();
            messageBroker.Publish(newGrade);


            // implement logic to send message to message broker

            return Ok();

        }

    }
}
