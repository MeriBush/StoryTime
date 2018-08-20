using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Data
{
    public class TwistPrompt
    {
        [Required]
        public Guid AdminId { get; set; }

        [Key]
        public int TwistId { get; set; }

        [Required]
        public string Twist { get; set; }

        [Required]
        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
