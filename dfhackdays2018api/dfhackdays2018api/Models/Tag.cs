using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dfhackdays2018.Models
{
    public class Tag
    {
        public Tag()
        {
        }

        //[BsonId]
        //public ObjectId TagId { get; set; }
        public string Name { get; set; }
    }
}
