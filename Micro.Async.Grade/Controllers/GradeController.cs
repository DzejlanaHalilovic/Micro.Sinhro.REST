using Micro.Async.Grade.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Micro.Async.Grade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {

        private readonly GradeDBContext _context;
        public GradeController(GradeDBContext context)
        {
            _context = context;
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


            // implement logic to send message to message broker

            return Ok();

        }

    }
}
