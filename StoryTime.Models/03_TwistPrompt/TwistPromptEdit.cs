using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Models
{
    public class TwistPromptEdit
    {
        [Display(Name ="Twist Id")]
        public int TwistId { get; set; }

        [Display(Name ="Plot Twist")]
        public string Twist { get; set; }
    }
}
