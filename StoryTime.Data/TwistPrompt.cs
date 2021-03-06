﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Data
{
    public class TwistPrompt
    {
        [Key]
        public int TwistId { get; set; }

        [Required]
        public Guid AdminId { get; set; }

        [Required]
        public string Twist { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
