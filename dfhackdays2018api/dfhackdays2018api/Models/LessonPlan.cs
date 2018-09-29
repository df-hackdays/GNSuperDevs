using System;
using System.Collections.Generic;
using dfhackdays2018api.Models;
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
        public string Title { get; set; }
        public Difficulty Difficulty { get; set; }
        //public List<Tag> Tags { get; set; }
        public List<ObjectId> Lessons { get; set; }
    }
}
