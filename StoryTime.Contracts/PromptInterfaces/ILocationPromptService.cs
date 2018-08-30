using StoryTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Contracts
{
    public interface ILocationPromptService
    {
        bool CreateLocationPrompt(LocationPromptCreate model);
        IEnumerable<LocationPromptListItem> GetLocationPrompts();
        LocationPromptDetail GetLocationPromptById(int LocationPromptId);
        bool UpdateLocationPrompt(LocationPromptEdit model);
        bool DeleteLocationPrompt(int LocationId);
    }
}
