using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Models
{
    public class LocationPromptListItem
    {
        public int LocationId { get; set; }
        public string Location { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name ="Created")]
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
