using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Data
{
    public class CharacterPrompt
    {
        [Required]
        public Guid AdminId { get; set; }

        [Key]
        public int CharacterId { get; set; }

        [Required]
        public string Character { get; set; }

        [Required]
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
