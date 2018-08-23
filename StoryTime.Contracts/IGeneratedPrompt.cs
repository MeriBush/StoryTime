using StoryTime.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Contracts
{
    public interface IGeneratedPrompt
    {
        string GetCharacter(ApplicationDbContext characterCtx);
        string GetLocation(ApplicationDbContext locationCtx);
        string GetTwist(ApplicationDbContext twistCtx);
    }
}
