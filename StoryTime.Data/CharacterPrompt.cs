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
        [Key]
        public int CharacterId { get; set; }

        [Required]
        public Guid AdminId { get; set; }

        [Required]
        public string Character { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
