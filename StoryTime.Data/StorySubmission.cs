using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Data
{
    public class StorySubmission
    {
        [Key]
        public int StoryId { get; set; }

        [Required]
        public Guid StudentId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string StoryTitle { get; set; }

        [Required]
        public string StoryText { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
