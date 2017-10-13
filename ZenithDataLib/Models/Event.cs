using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib.Models
{
    class Event
    {
        // EventId
        // Event from date and time
        // Event to date and time
        // Entered by username
        // ActivityCategory (FK)
        // CreationDate
        // isActive

        public int EventId { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Entered By")]
        public string EnteredBy { get; set; }

        [Required]
        [Display(Name = "Activity Category")]
        [ForeignKey("Activity")]
        public int ActivityCategory { get; set; }

        [Required]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        public Activity Activity;
    }
}
