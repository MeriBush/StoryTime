using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Models
{
    public class LocationPromptEdit
    {
        [Display(Name ="Location ID")]
        public int LocationId { get; set; }
        public string Location { get; set; }
    }
}
