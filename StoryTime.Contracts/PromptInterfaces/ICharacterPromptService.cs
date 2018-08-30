using StoryTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Contracts
{
    public interface ICharacterPromptService
    {
        bool CreateCharacterPrompt(CharacterPromptCreate model);
        IEnumerable<CharacterPromptListItem> GetCharacterPrompts();
        CharacterPromptDetail GetCharacterPromptById(int CharacterPromptId);
        bool UpdateCharacterPrompt(CharacterPromptEdit model);
        bool DeleteCharacterPrompt(int CharacterId);
    }
}
