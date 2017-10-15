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

            // ensure that only active events are passed
            var activities = db.Activities.Include(a => a.events)
                                .Where(a => a.events
                                             .Any(e => e.StartDate >= startOfWeek &&
                                                  e.EndDate <= endOfWeek &&
                                                  e.IsActive == true))
                                .Select(a => a).ToList();

            var WeeklyInfo = new List<DayInfo>();

            foreach (var a in activities)
            {
                foreach (var e in a.events)
                {
                    if (!(e.StartDate >= startOfWeek && e.EndDate <= endOfWeek && e.IsActive == true))
                    {
                        continue;
                    }
                    var day = e.StartDate.Date;
                    var dayInfo = WeeklyInfo.FirstOrDefault(d => d.Day == day);

                    if (dayInfo == null)
                    {
                        dayInfo = new DayInfo { Day = day, Events = new List<EventInfo>() };
                        WeeklyInfo.Add(dayInfo);
                    }
                    dayInfo.Events.Add(new EventInfo { StartDate = e.StartDate,
                                                        EndDate  = e.EndDate,
                                             ActivityDescription = a.ActivityDescription });
                }
            }
            WeeklyInfo = WeeklyInfo.OrderBy(w => w.Day).ToList();

            foreach (var day in WeeklyInfo)
            {
                day.Events = day.Events.OrderBy(e => e.StartDate).ToList();
            }

            return View(WeeklyInfo);
        }

        public class DayInfo
        {
            public DateTime Day { get; set; }
            public List<EventInfo> Events { get; set; }
        }

        public class EventInfo
        {

            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public String ActivityDescription { get; set; }
        }
    }
}
