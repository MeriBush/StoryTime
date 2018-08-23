using StoryTime.Contracts;
using StoryTime.Data;
using StoryTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Services
{
    public class StorySubmissionService : IGeneratedPrompt
    {
        private readonly Guid _userId;

        public StorySubmissionService(Guid studentId)
        {
            _userId = studentId;
        }

        public bool CreateStorySubmission(StorySubmissionCreate model)
        {
            var entity =
                new StorySubmission()
                {
                    StudentId = _userId,
                    StoryTitle = model.StoryTitle,
                    StoryText = model.StoryText,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.StorySubmissions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public string GetCharacter(ApplicationDbContext characterCtx)
        {
            Random random = new Random();
            var characterList = characterCtx.CharacterPrompts.ToList();
            var randomNumber = random.Next(0, characterList.Count+1);
            var character = characterList[randomNumber];
            return character.Character;
        }

        public string GetLocation(ApplicationDbContext locationCtx)
        {
            Random random = new Random();
            var locationList = locationCtx.LocationPrompts.ToList();
            int randomNumber = random.Next(0, locationList.Count + 1);
            var location = locationList[randomNumber];
            return location.Location;

        }

        public string GetTwist(ApplicationDbContext twistCtx)
        {
            Random random = new Random();
            var twistList = twistCtx.TwistPrompts.ToList();
            int randomNumber = random.Next(0, twistList.Count + 1);
            var twist = twistList[randomNumber];
            return twist.Twist;
        }
    }
}
