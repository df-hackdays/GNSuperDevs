using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dfhackdays2018.Models
{
    public class LessonPlan
    {
        public LessonPlan()
        {
        }

        [BsonId]
        public ObjectId LessonPlanId { get; set; }
        public string Difficulty { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}
