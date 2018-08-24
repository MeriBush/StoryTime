﻿using StoryTime.Contracts;
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

        public IEnumerable<StorySubmissionListItem> AdminGetAllStorySubmissions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .StorySubmissions
                    .Select(
                        e =>
                        new StorySubmissionListItem
                        {
                            StoryId = e.StoryId,
                            StudentId = e.StudentId,
                            StudentName = "",
                            StoryTitle = e.StoryTitle,
                            StoryText = e.StoryText,
                            CreatedUtc = DateTimeOffset.Now
                        });

                return query.ToArray();
            }
        }

        public IEnumerable<StorySubmissionListItem> GetStorySubmissions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .StorySubmissions
                    .Where(e => e.StudentId == _userId)
                    .Select(
                        e =>
                        new StorySubmissionListItem
                        {
                            StoryId = e.StoryId,
                            StudentId = e.StudentId,
                            StudentName = "",
                            StoryTitle = e.StoryTitle,
                            StoryText = e.StoryText,
                            CreatedUtc = DateTimeOffset.Now
                        });
                
                return query.ToArray();
            }
        }

        public StorySubmissionCreate PromptResult()
        {
            StorySubmissionCreate model = new StorySubmissionCreate();
            using (var ctx = new ApplicationDbContext())
            {
                model.Character = GetCharacter(ctx);
                model.Location = GetLocation(ctx);
                model.Twist = GetTwist(ctx);
                return model;
            }
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
            var randomNumber = random.Next(0, characterList.Count);
            var character = characterList[randomNumber];
            return character.Character;
        }

        public string GetLocation(ApplicationDbContext locationCtx)
        {
            Random random = new Random();
            var locationList = locationCtx.LocationPrompts.ToList();
            int randomNumber = random.Next(0, locationList.Count);
            var location = locationList[randomNumber];
            return location.Location;

        }

        public string GetTwist(ApplicationDbContext twistCtx)
        {
            Random random = new Random();
            var twistList = twistCtx.TwistPrompts.ToList();
            int randomNumber = random.Next(0, twistList.Count);
            var twist = twistList[randomNumber];
            return twist.Twist;
        }

        public IEnumerable<StorySubmissionListItem> GetStudentNameFromId(IEnumerable<StorySubmissionListItem> listItem)
        {
            using (var ctx = new ApplicationDbContext())
            {
                foreach (var item in listItem)
                {
                    foreach (var student in ctx.Users)
                    {
                        if(Guid.Parse(student.Id) == item.StudentId)
                        {
                            item.StudentName = student.UserName;
                        }
                    }
                }
                return listItem;
            }
        }
    }
}
