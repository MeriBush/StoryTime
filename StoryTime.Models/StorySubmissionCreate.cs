using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Models
{
    public class StorySubmissionCreate
    {
        public int StoryId { get; set; }
        public Guid StudentId { get; set; }
        public string StoryTitle { get; set; }
        public string StoryText { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
