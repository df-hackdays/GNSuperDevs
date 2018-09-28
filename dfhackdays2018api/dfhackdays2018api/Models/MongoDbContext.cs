using System;
using Blueshift.EntityFrameworkCore.MongoDB.Annotations;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace dfhackdays2018.Models
{
    [MongoDatabase("dfhackdays2018")]
    public class MongoDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<LessonPlan> LessonPlans { get; set; }

        public MongoDbContext() : this(new DbContextOptions<MongoDbContext>())
        {
        }

        public MongoDbContext(DbContextOptions<MongoDbContext> mongoDbContextOptions) : base(mongoDbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "mongodb+srv://admin:Scotiabank1@cluster0-77bmz.mongodb.net/test?retryWrites=true";
            //optionsBuilder.UseMongoDb(connectionString);

            var mongoUrl = new MongoUrl(connectionString);
            //optionsBuilder.UseMongoDb(mongoUrl);

            MongoClientSettings settings = MongoClientSettings.FromUrl(mongoUrl);
            //settings.SslSettings = new SslSettings
            //{
            //    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
            //};
            //optionsBuilder.UseMongoDb(settings);

            MongoClient mongoClient = new MongoClient(settings);
            optionsBuilder.UseMongoDb(mongoClient);
        }
    }
}

