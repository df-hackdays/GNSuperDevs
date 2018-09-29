using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dfhackdays2018.Models
{
    public class Student
    {
        public Student()
        {
        }

        [BsonId]
        public ObjectId StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public Profession Profession { get; set; }
        public List<Profession> Aspirations { get; set; }
    }
}
