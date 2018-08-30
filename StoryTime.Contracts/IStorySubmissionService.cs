using StoryTime.Data;
using StoryTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Contracts
{
    public interface IStorySubmissionService
    {
        IEnumerable<StorySubmissionListItem> AdminGetAllStorySubmissions();
        IEnumerable<StorySubmissionListItem> GetStorySubmissions();
        StorySubmissionCreate PromptResult();
        bool CreateStorySubmission(StorySubmissionCreate model);
        string GetCharacter(ApplicationDbContext characterCtx);
        string GetLocation(ApplicationDbContext locationCtx);
        string GetTwist(ApplicationDbContext twistCtx);
        IEnumerable<StorySubmissionListItem> GetStudentNameFromId(IEnumerable<StorySubmissionListItem> listItem);
    }
}
