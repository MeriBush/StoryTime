using StoryTime.Data;
using StoryTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Services
{
    public class TwistPromptService
    {
        private readonly Guid _userId;

        public TwistPromptService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTwistPrompt(TwistPromptCreate model)
        {
            var entity =
                new TwistPrompt()
                {
                    AdminId = _userId,
                    Twist = model.Twist,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.TwistPrompts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TwistPromptListItem> GetTwistPrompts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .TwistPrompts
                    .Where(e => e.AdminId == _userId)
                    .Select(
                        e =>
                        new TwistPromptListItem
                        {
                            TwistId = e.TwistId,
                            Twist = e.Twist,
                            CreatedUtc = e.CreatedUtc
                        }
                        );
                return query.ToArray();
            }
        }

        public TwistPromptDetail GetTwistPromptById(int TwistPromptId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .TwistPrompts
                    .Single(e => e.TwistId == TwistPromptId && e.AdminId == _userId);
                return
                    new TwistPromptDetail
                    {
                        TwistId = entity.TwistId,
                        Twist = entity.Twist,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateTwistPrompt(TwistPromptEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .TwistPrompts
                    .Single(e => e.TwistId == model.TwistId && e.AdminId == _userId);

                entity.Twist = model.Twist;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTwistPrompt(int TwistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .TwistPrompts
                    .Single(e => e.TwistId == TwistId && e.AdminId == _userId);
                ctx.TwistPrompts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
