using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib.Models
{
    public class Activity
    {
        // ActivityCategoryId - primary key
        // ActivityDescription
        // CreationDate

        // PK
        [Key]
        [Display(Name = "Activity")]
        public int ActivityCategoryId { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string ActivityDescription { get; set; }

        [Required]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        public List<Event> events { get; set; }
    }
}
