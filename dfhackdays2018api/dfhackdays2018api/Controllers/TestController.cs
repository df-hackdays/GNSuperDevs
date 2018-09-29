using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dfhackdays2018.Models;
using dfhackdays2018api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dfhackdays2018api.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            /*
            using (MongoDbContext context = new MongoDbContext())
            {
                Profession profession = new Profession()
                {
                    Name = "Network Engineer"
                };
                context.Professions.Add(profession);
                context.SaveChanges();
            }

            using (MongoDbContext context = new MongoDbContext())
            {
                Student student = new Student()
                {
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "john.smith@scotiabank.com",
                    Birthday = new DateTime(1985, 2, 8),
                    Gender = "Male",
                    Profession = context.Professions.SingleOrDefault(prof => prof.Name == "Network Engineer").ProfessionId
                };
                context.Students.Add(student);
                context.SaveChanges();
            }*/

            using (MongoDbContext context = new MongoDbContext())
            {
                Profession profession = new Profession()
                {
                    Name = "Accountant",
                    Tags = new List<Tag>() { new Tag() { Name = "accounting" } }
                };

                context.Professions.Add(profession);
                context.SaveChanges();
            }
            
            List<Lesson> lessons = new List<Lesson>() {
                new Lesson() { Title = "Coding Fundamentals 1 for Accountants", Description = "Apply problem solving skills you have already developed in being an accountant, and leverage this in building fundamental skills for coding", Difficulty = Difficulty.Low, Tags = new List<Tag>() { new Tag() { Name = "accounting" } } },
                new Lesson() { Title = "Accounting Automation Fundamentals 1", Description = "Use ready-built programming tools to perform basic accounting tasks 1", Difficulty = Difficulty.Intermediate, Tags = new List<Tag>() { new Tag() { Name = "accounting" } } },
                new Lesson() { Title = "Accounting Automation Fundamentals 2", Description = "Use ready-built programming tools to perform basic accounting tasks 2", Difficulty = Difficulty.Intermediate, Tags = new List<Tag>() { new Tag() { Name = "accounting" } } },
                new Lesson() { Title = "Accounting Automation Fundamentals 3", Description = "Use ready-built programming tools to perform basic accounting tasks 3", Difficulty = Difficulty.Intermediate, Tags = new List<Tag>() { new Tag() { Name = "accounting" } } },
            };

            foreach (Lesson lesson in lessons)
            {
                using (MongoDbContext context = new MongoDbContext())
                {
                    context.Lessons.Add(lesson);
                    context.SaveChanges();
                }
                    
            }



            /*
            using (MongoDbContext context = new MongoDbContext())
            {
                context.LessonPlans.Add(new LessonPlan() { Title = "Road to CCIE", Difficulty = "Advanced", Lessons = new List<ObjectId>() { context.Lessons.SingleOrDefault(less => less.Title == "CCNA").LessonId, context.Lessons.SingleOrDefault(less => less.Title == "CCNP 1").LessonId, context.Lessons.SingleOrDefault(less => less.Title == "CCNP 2").LessonId, context.Lessons.SingleOrDefault(less => less.Title == "CCNP 3").LessonId, context.Lessons.SingleOrDefault(less => less.Title == "CCIE 1").LessonId } });
                context.SaveChanges();
            }*/

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
