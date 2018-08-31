using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Models
{
    public class StorySubmissionCreate
    {
        public string Character { get; set; }
        public string Location { get; set; }
        public string Twist { get; set; }

        [Display(Name ="Story Title")]
        public string StoryTitle { get; set; }

        [Display(Name ="Once upon a time...")]
        public string StoryText { get; set; }
    }
}
