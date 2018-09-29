using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dfhackdays2018.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace dfhackdays2018.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            using (MongoDbContext context = new MongoDbContext())
            {
                return context.Students.ToList();
            }
        }

        // GET api/values/5
        [HttpGet("{studentId}")]
        public ActionResult<Student> Get(string studentId)
        {
            using (MongoDbContext context = new MongoDbContext())
            {
                return context.Students.SingleOrDefault(stud => stud.StudentId == ObjectId.Parse(studentId));
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Student> Post([FromBody] StudentViewModel newStudentViewModel)
        {
            using (MongoDbContext context = new MongoDbContext())
            {
                if (!context.Students.Any(stud => stud.Email == newStudentViewModel.Email))
                {
                    Student newStudent = Map(newStudentViewModel);
                    newStudent.Profession = ObjectId.Parse(newStudentViewModel.Profession);
                    List<ObjectId> aspirations = new List<ObjectId>();
                    newStudentViewModel.Aspirations.ForEach(a => aspirations.Add(ObjectId.Parse(a)));
                    newStudent.Aspirations = aspirations;

                    context.Students.Add(newStudent);
                    context.SaveChanges();
                }
            }

            using (MongoDbContext context = new MongoDbContext())
            {
                if (context.Students.Any(stud => stud.Email == newStudentViewModel.Email))
                {
                    return context.Students.SingleOrDefault(stud => stud.Email == newStudentViewModel.Email);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        // PUT api/values/5
        [HttpPut("{studentId}")]
        public IActionResult Put([FromRoute] string studentId, [FromBody] StudentViewModel updatedStudentViewModel)
        {
            using (MongoDbContext context = new MongoDbContext())
            {
                if (!context.Students.Any(stud => stud.StudentId == ObjectId.Parse(studentId)))
                {
                    return NotFound();
                }

                Student updatedStudent = Map(updatedStudentViewModel);
                updatedStudent.StudentId = ObjectId.Parse(studentId);
                updatedStudent.Profession = ObjectId.Parse(updatedStudentViewModel.Profession);
                List<ObjectId> aspirations = new List<ObjectId>();
                updatedStudentViewModel.Aspirations.ForEach(a => aspirations.Add(ObjectId.Parse(a)));
                updatedStudent.Aspirations = aspirations;

                context.Students.Update(updatedStudent);
                context.SaveChanges();

                return Ok();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private Student Map(StudentViewModel asvm)
        {
            Student student = new Student()
            {
                FirstName = asvm.FirstName,
                LastName = asvm.LastName,
                Email = asvm.Email,
                Gender = asvm.Gender,
                Birthday = asvm.Birthday,
                SignUpDate = asvm.SignUpDate
            };

            return student;
        }
    }
}
