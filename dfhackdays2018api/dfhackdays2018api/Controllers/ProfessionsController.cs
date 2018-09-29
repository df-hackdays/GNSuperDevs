using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dfhackdays2018.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dfhackdays2018api.Controllers
{
    [Route("api/[controller]")]
    public class ProfessionsController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Profession> Get()
        {
            using (MongoDbContext context = new MongoDbContext())
            {
                return context.Professions.ToList();
            }
        }

        // GET api/values/5
        [HttpGet("{professionId}")]
        public Profession Get(string professionId)
        {
            using (MongoDbContext context = new MongoDbContext())
            {
                return context.Professions.SingleOrDefault(prof => prof.ProfessionId == ObjectId.Parse(professionId));
            }
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
