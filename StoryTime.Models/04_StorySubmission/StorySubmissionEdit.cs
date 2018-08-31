using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Models
{
    public class StorySubmissionEdit
    {
        [Display(Name ="Story ID")]
        public int StoryId { get; set; }
        [Display(Name ="Title")]
        public string StoryTitle { get; set; }
        [Display(Name ="Story")]
        public string StoryText { get; set; }
    }
}
