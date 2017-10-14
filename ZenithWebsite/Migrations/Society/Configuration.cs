namespace ZenithWebsite.Migrations.Society
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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
            context.Activities.AddOrUpdate(a => a.ActivityCategoryId, getActivities(context));
            context.SaveChanges();

            context.Events.AddOrUpdate(b => b.EventId, getEvents(context));
            context.SaveChanges();
        }

        // *************************
        // Activities
        // *************************
        public Activity[] getActivities(ApplicationDbContext context)
        {
            List<Activity> activities = new List<Activity>
            {
                new Activity()
                {
                    ActivityDescription = "Senior's Golf Tournament",
                    CreationDate = new DateTime(2017,10,17,8,00,00)
                },
                new Activity()
                {
                    ActivityDescription = "Leadership General Assembly Meeting",
                    CreationDate = new DateTime(2017,10,17,8,00,00)
                },
                new Activity()
                {
                    ActivityDescription = "Youth Bowling Tournament",
                    CreationDate = new DateTime(2017,10,17,8,00,00)
                },
                new Activity()
                {
                    ActivityDescription = "Young ladies cooking lessons",
                    CreationDate = new DateTime(2017,10,17,8,00,00)
                },
                new Activity()
                {
                    ActivityDescription = "Youth craft lessons",
                    CreationDate = new DateTime(2017,10,17,8,00,00)
                },
                new Activity()
                {
                    ActivityDescription = "Youth choir practice",
                    CreationDate = new DateTime(2017,10,17,8,00,00)
                },
                new Activity()
                {
                    ActivityDescription = "Pancake Breakfast",
                    CreationDate = new DateTime(2017,10,17,8,00,00)
                },
                new Activity()
                {
                    ActivityDescription = "Swimming Lessons for the youth",
                    CreationDate = new DateTime(2017,10,17,8,00,00)
                },
                new Activity()
                {
                    ActivityDescription = "Swimming Exercise for parents",
                    CreationDate = new DateTime(2017,10,17,8,00,00)
                },
                new Activity()
                {
                    ActivityDescription = "Bingo Tournament",
                    CreationDate = new DateTime(2017,10,17,8,00,00)
                },
                new Activity()
                {
                    ActivityDescription = "BBQ Lunch",
                    CreationDate = new DateTime(2017,10,17,8,00,00)
                },
                new Activity()
                {
                    ActivityDescription = "Garage Sale",
                    CreationDate = new DateTime(2017,10,17,8,00,00)
                }
            };
            return activities.ToArray();
        }

        // *************************
        // Events
        // *************************
        public Event[] getEvents(ApplicationDbContext context)
        {
            List<Event> events = new List<Event>
            {
                new Event()
                {
                    StartDate = new DateTime(2017,10,17,8,30,0),
                    EndDate = new DateTime(2017,10,17,10,30,0),
                    EnteredBy = "a",
                    ActivityCategoryId = context.Activities
                                    .FirstOrDefault(a => a.ActivityCategoryId == 1)
                                    .ActivityCategoryId,
                    CreationDate = new DateTime(2017,10,17,8,00,00),
                    IsActive = true
                },
                new Event()
                {
                    StartDate = new DateTime(2017,10,18,8,30,0),
                    EndDate = new DateTime(2017,10,18,10,30,0),
                    EnteredBy = "a",
                    ActivityCategoryId = context.Activities
                                    .FirstOrDefault(a => a.ActivityCategoryId == 2)
                                    .ActivityCategoryId,
                    CreationDate = new DateTime(2017,10,18,8,00,00),
                    IsActive = true
                },
                new Event()
                {
                    StartDate = new DateTime(2017,10,20,5,30,0),
                    EndDate = new DateTime(2017,10,20,7,15,0),
                    EnteredBy = "a",
                    ActivityCategoryId = context.Activities
                                    .FirstOrDefault(a => a.ActivityCategoryId == 3)
                                    .ActivityCategoryId,
                    CreationDate = new DateTime(2017,10,20,5,30,0),
                    IsActive = true
                },
                new Event()
                {
                    StartDate = new DateTime(2017,10,20,7,00,0),
                    EndDate = new DateTime(2017,10,20,8,00,0),
                    EnteredBy = "a",
                    ActivityCategoryId = context.Activities
                                    .FirstOrDefault(a => a.ActivityCategoryId == 4)
                                    .ActivityCategoryId,
                    CreationDate = new DateTime(2017,10,20,7,00,0),
                    IsActive = true
                },
                new Event()
                {
                    StartDate = new DateTime(2017,10,21,8,30,0),
                    EndDate = new DateTime(2017,10,21,10,30,0),
                    EnteredBy = "a",
                    ActivityCategoryId = context.Activities
                                    .FirstOrDefault(a => a.ActivityCategoryId == 5)
                                    .ActivityCategoryId,
                    CreationDate = new DateTime(2017,10,21,8,30,0),
                    IsActive = true
                },
                new Event()
                {
                    StartDate = new DateTime(2017,10,21,10,30,0),
                    EndDate = new DateTime(2017,10,21,12,00,0),
                    EnteredBy = "a",
                    ActivityCategoryId = context.Activities
                                    .FirstOrDefault(a => a.ActivityCategoryId == 6)
                                    .ActivityCategoryId,
                    CreationDate = new DateTime(2017,10,21,10,30,0),
                    IsActive = true
                },
                new Event()
                {
                    StartDate = new DateTime(2017,10,21,12,00,0),
                    EndDate = new DateTime(2017,10,21,13,30,0),
                    EnteredBy = "a",
                    ActivityCategoryId = context.Activities
                                    .FirstOrDefault(a => a.ActivityCategoryId == 7)
                                    .ActivityCategoryId,
                    CreationDate = new DateTime(2017,10,21,12,00,0),
                    IsActive = true
                },
                new Event()
                {
                    StartDate = new DateTime(2017,10,22,7,30,0),
                    EndDate = new DateTime(2017,10,22,8,30,0),
                    EnteredBy = "a",
                    ActivityCategoryId = context.Activities
                                    .FirstOrDefault(a => a.ActivityCategoryId == 8)
                                    .ActivityCategoryId,
                    CreationDate = new DateTime(2017,10,22,7,30,0),
                    IsActive = true
                },
                new Event()
                {
                    StartDate = new DateTime(2017,10,22,8,30,0),
                    EndDate = new DateTime(2017,10,22,10,30,0),
                    EnteredBy = "a",
                    ActivityCategoryId = context.Activities
                                    .FirstOrDefault(a => a.ActivityCategoryId == 9)
                                    .ActivityCategoryId,
                    CreationDate = new DateTime(2017,10,22,8,30,0),
                    IsActive = true
                },
                new Event()
                {
                    StartDate = new DateTime(2017,10,22,8,30,0),
                    EndDate = new DateTime(2017,10,22,10,30,0),
                    EnteredBy = "a",
                    ActivityCategoryId = context.Activities
                                    .FirstOrDefault(a => a.ActivityCategoryId == 10)
                                    .ActivityCategoryId,
                    CreationDate = new DateTime(2017,10,22,8,30,0),
                    IsActive = true
                },
                new Event()
                {
                    StartDate = new DateTime(2017,10,22,10,30,0),
                    EndDate = new DateTime(2017,10,22,12,00,0),
                    EnteredBy = "a",
                    ActivityCategoryId = context.Activities
                                    .FirstOrDefault(a => a.ActivityCategoryId == 11)
                                    .ActivityCategoryId,
                    CreationDate = new DateTime(2017,10,22,8,30,0),
                    IsActive = true
                },
                new Event()
                {
                    StartDate = new DateTime(2017,10,22,12,00,0),
                    EndDate = new DateTime(2017,10,22,13,00,0),
                    EnteredBy = "a",
                    ActivityCategoryId = context.Activities
                                    .FirstOrDefault(a => a.ActivityCategoryId == 12)
                                    .ActivityCategoryId,
                    CreationDate = new DateTime(2017,10,22,12,00,0),
                    IsActive = true
                },
                new Event()
                {
                    StartDate = new DateTime(2017,10,22,13,00,0),
                    EndDate = new DateTime(2017,10,22,16,00,0),
                    EnteredBy = "a",
                    ActivityCategoryId = context.Activities
                                    .FirstOrDefault(a => a.ActivityCategoryId == 13)
                                    .ActivityCategoryId,
                    CreationDate = new DateTime(2017,10,22,13,00,0),
                    IsActive = true
                }
            };
            return events.ToArray();
        }
    }
}
