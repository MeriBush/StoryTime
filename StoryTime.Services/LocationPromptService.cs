using StoryTime.Data;
using StoryTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTime.Services
{
    public class LocationPromptService
    {
        private readonly Guid _userId;

        public LocationPromptService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLocationPrompt(LocationPromptCreate model)
        {
            var entity =
                new LocationPrompt()
                {
                    AdminId = _userId,
                    Location = model.Location,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.LocationPrompts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LocationPromptListItem> GetLocationPrompts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .LocationPrompts
                    .Where(e => e.AdminId == _userId)
                    .Select(
                        e =>
                        new LocationPromptListItem
                        {
                            LocationId = e.LocationId,
                            Location = e.Location,
                            CreatedUtc = e.CreatedUtc
                        }
                        );
                return query.ToArray();
            }
        }
    }
}
