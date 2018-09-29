using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dfhackdays2018.Models
{
    public class Profession
    {
        public Profession()
        {
        }

        [BsonId]
        public ObjectId ProfessionId { get; set; }
        public string Name { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
