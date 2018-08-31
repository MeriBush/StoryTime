using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Models
{
    public class TwistPromptDetail
    {
        [Display(Name ="Twist ID")]
        public int TwistId { get; set; }

        [Display(Name ="Plot Twist")]
        public string Twist { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        public override string ToString() => $"[{TwistId}] {Twist}";
    }
}
