namespace ZenithWebsite.Migrations.Society
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZenithDataLib.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZenithDataLib.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Society";
        }

        protected override void Seed(ZenithDataLib.Models.ApplicationDbContext context)
        {
            // *************************
            // Activities
            // *************************
            List<Activity> activities = new List<Activity>
            {
                new Activity()
                {
                    ActivityDescription = "Senior's Golf Tournament",
                    CreationDate = new DateTime(2017,10,17,8,00,00)
                }
            };
            context.Activities.AddOrUpdate(a => a.ActivityCategoryId, activities.ToArray());

            // *************************
            // Events
            // *************************
            List<Event> events = new List<Event>
            {
                new Event()
                {
                    StartDate = new DateTime(2017,10,17,8,30,0),
                    EndDate = new DateTime(2017,10,17,10,30,0),
                    EnteredBy = "a",
                    ActivityCategory = 1,
                    CreationDate = new DateTime(2017,10,17,8,00,00),
                    IsActive = true
                }
            };
            context.Events.AddOrUpdate(b => b.EventId, events.ToArray());
            context.SaveChanges();
        }
    }
}
