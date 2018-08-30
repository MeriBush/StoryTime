using StoryTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Contracts
{
    public interface ITwistPromptService
    {
        bool CreateTwistPrompt(TwistPromptCreate model);
        IEnumerable<TwistPromptListItem> GetTwistPrompts();
        TwistPromptDetail GetTwistPromptById(int TwistPromptId);
        bool UpdateTwistPrompt(TwistPromptEdit model);
        bool DeleteTwistPrompt(int TwistId);
    }
}
