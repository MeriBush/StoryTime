using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Models
{
    public class TwistPromptCreate
    {
        [Required]
        [Display(Name ="New Plot Twist")]
        public string Twist { get; set; }
    }
}
