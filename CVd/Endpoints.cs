using CVd.Data;
using Microsoft.EntityFrameworkCore;

namespace CVd
{
    public static partial class Endpoints
    {
        public static void Configure(WebApplication app, bool mapAdditional = false)
        {
            app.MapGet("/user/{id}", (CvDbContext db, int id, string lang) =>
            {
                try
                {
                    var user = db.Users
                       .Include(u => u.Contacts)
                       .Include(u => u.Milestones)
                       .Include(u => u.Skills)
                       .Include(u => u.Decorations)
                       .FirstOrDefault(u => u.Id == id);

                    if (user == null) { return Results.NotFound(); }

                    //single db query, then aggregate in-memory
                    var descriptions = db.MilestoneDescriptions.Where(md =>
                        md.LanguageCode == lang && user.Decorations.Select(d => d.Id).Contains(md.DescriptionId));

                    foreach (var milestone in user.Milestones)
                    {
                        milestone.Description = descriptions.FirstOrDefault(d => d.DescriptionId == milestone.Id)?.Value;
                    }

                    return Results.Ok(user);
                }
                catch
                {
                    return Results.BadRequest();
                }
            });

            if (mapAdditional)
            {
                app.MapAdditional();
            }
        }
    }
}