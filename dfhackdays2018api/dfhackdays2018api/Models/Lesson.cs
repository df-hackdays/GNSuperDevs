using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dfhackdays2018.Models
{
    public class Lesson
    {
        public Lesson()
        {
        }

        [BsonId]
        public ObjectId LessonId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Tag> Tags { get; set; }
        public string Content { get; set; }
    }
}
