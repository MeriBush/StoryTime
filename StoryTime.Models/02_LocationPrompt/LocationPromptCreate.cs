﻿using System;
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
        [Display(Name ="New Location")]
        public string Location { get; set; }
    }
}
