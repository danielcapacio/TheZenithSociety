using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZenithDataLib.Models;
using System.Data.Entity;

namespace ZenithWebSite.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            DateTime today = DateTime.Today;
            DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            DateTime endOfWeek = startOfWeek.AddDays(7);
            
            // getting events events that are within range of current start and end day of the week
            // pulling active events only
            var activities = db.Activities.Include(a => a.events)
                                          .Where(a => a.events.Any(e => e.StartDate >= startOfWeek &&
                                                                        e.EndDate <= endOfWeek &&
                                                                        e.IsActive == true))
                                          .Select(a => a).ToList();

            var WeekInfo = new List<DayInfo>();

            foreach (var a in activities)
            {
                foreach (var e in a.events)
                {
                    // check if event is within the current week and isActive
                    if (!(e.StartDate >= startOfWeek && e.EndDate <= endOfWeek && e.IsActive == true))
                    {
                        continue;
                    }
                    var day = e.StartDate.Date;
                    var dayInfo = WeekInfo.FirstOrDefault(d => d.Day == day);

                    // check if dayInfo is empty before adding events
                    // we don't want duplicate days for each event
                    if (dayInfo == null)
                    {
                        dayInfo = new DayInfo
                        {
                            Day = day,
                            Events = new List<EventInfo>()
                        };
                        WeekInfo.Add(dayInfo);
                    }

                    dayInfo.Events.Add(new EventInfo { StartDate = e.StartDate,
                                                        EndDate = e.EndDate,
                                                        ActivityDescription = a.ActivityDescription });
                }
            }
            WeekInfo = WeekInfo.OrderBy(w => w.Day).ToList();

            foreach (var day in WeekInfo)
            {
                day.Events = day.Events.OrderBy(e => e.StartDate).ToList();
            }

            // Passing a list of Days which contains Events which contains StartDate, EndDate, and desc.
            return View(WeekInfo);
        }

        /*
         * Display start time, end time, and description.
         */
        public class EventInfo
        {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public String ActivityDescription { get; set; }
        }

        /*
         * Contains days which hold events.
         */
        public class DayInfo
        {
            public DateTime Day { get; set; }
            public List<EventInfo> Events { get; set; }
        }
    }
}
