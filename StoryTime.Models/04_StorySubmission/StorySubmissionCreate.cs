using System;
using System.Collections.Generic;
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

        public string StoryTitle { get; set; }
        public string StoryText { get; set; }
    }
}
