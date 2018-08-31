using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Models
{
    public class StorySubmissionDetail
    {
        [Display(Name ="Story ID")]
        public int StoryId { get; set; }
        public Guid StudentId { get; set; }

        [Display(Name ="Student")]
        public string StudentName { get; set; }

        [Display(Name ="Title")]
        public string StoryTitle { get; set; }

        [Display(Name ="Story")]
        public string StoryText { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        public override string ToString() => $"[{StoryId}] {StoryTitle}";
    }
}
