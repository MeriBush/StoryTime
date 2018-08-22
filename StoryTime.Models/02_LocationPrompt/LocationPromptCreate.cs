using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Models
{
    public class LocationPromptCreate
    {
        [Required]
        public string Location { get; set; }
    }
}
