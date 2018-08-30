using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Models
{
    public class StorySubmissionListItem
    {
        public int StoryId { get; set; }
        public Guid StudentId { get; set; }
        public string StudentName { get; set; }
        public string StoryTitle { get; set; }

        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
