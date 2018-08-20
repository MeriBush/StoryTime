using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Data
{
    public class LocationPrompt
    {
        [Required]
        public Guid AdminId { get; set; }

        [Key]
        public int LocationId { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
