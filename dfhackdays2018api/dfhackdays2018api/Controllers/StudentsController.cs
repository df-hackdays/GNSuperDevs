using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dfhackdays2018.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace dfhackdays2018.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly MongoDbContext _context;

        public StudentsController(MongoDbContext mongoDbContext)
        {
            _context = mongoDbContext;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return _context.Students.ToList();
        }

        // GET api/values/5
        [HttpGet("{studentId}")]
        public ActionResult<Student> Get(string studentId)
        {
            return _context.Students.SingleOrDefault(stud => stud.StudentId == ObjectId.Parse(studentId));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Student newStudent)
        {
            if (!_context.Students.Any(stud => stud.Email == newStudent.Email))
            {
                _context.Students.Add(newStudent);
                _context.SaveChanges();
            }

            return;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromQuery] ObjectId studentId, [FromBody] Student updatedStudent)
        {
            if (!_context.Students.Any(stud => stud.StudentId == studentId))
            {
                return NotFound();
            }

            updatedStudent.StudentId = studentId;

            _context.Students.Update(updatedStudent);

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
