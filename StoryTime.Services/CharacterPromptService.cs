using StoryTime.Data;
using StoryTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Services
{
    public class CharacterPromptService
    {
        private readonly Guid _userId;

        public CharacterPromptService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCharacterPrompt(CharacterPromptCreate model)
        {
            var entity =
                new CharacterPrompt()
                {
                    AdminId = _userId,
                    Character = model.Character,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.CharacterPrompts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CharacterPromptListItem> GetCharacterPrompts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .CharacterPrompts
                    .Where(e => e.AdminId == _userId)
                    .Select(
                        e =>
                        new CharacterPromptListItem
                        {
                            CharacterId = e.CharacterId,
                            Character = e.Character,
                            CreatedUtc = e.CreatedUtc
                        });
                return query.ToArray();
            }
        }

        public CharacterPromptDetail GetCharacterPromptById(int CharacterPromptId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .CharacterPrompts
                    .Single(e => e.CharacterId == CharacterPromptId && e.AdminId == _userId);
                return
                    new CharacterPromptDetail
                    {
                        CharacterId = entity.CharacterId,
                        Character = entity.Character,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateCharacterPrompt(CharacterPromptEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .CharacterPrompts
                    .Single(e => e.CharacterId == model.CharacterId && e.AdminId == _userId);

                entity.Character = model.Character;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
