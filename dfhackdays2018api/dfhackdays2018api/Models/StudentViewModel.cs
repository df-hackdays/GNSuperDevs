using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace dfhackdays2018.Models
{
    public class StudentViewModel
    {
        public StudentViewModel()
        {
        }

        [BsonId]
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Profession { get; set; }
        public List<string> Aspirations { get; set; }
        public DateTime SignUpDate { get; set; }
    }
}
