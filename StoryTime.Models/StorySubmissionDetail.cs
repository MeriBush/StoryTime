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
        public int StoryId { get; set; }
        public string StoryTitle { get; set; }
        public string StoryText { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        public override string ToString() => $"[{StoryId}] {StoryTitle}";
    }
}
