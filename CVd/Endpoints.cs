using CVd.Data;
using Microsoft.EntityFrameworkCore;

namespace CVd
{
    public static partial class Endpoints
    {
        public static void Configure(WebApplication app, bool includeMutations = false)
        {
            app.MapGet();

            if (includeMutations)
            {
                app.MapPost()
                 .MapDelete();
            }
        }

        private static WebApplication MapGet(this WebApplication app)
        {
            app.MapGet("/user/{id}", (CvDbContext db, int id, string lang) => 
            {
                try
                {
                    var user = db.Users
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

            app.MapGet("/skills/{userId}", (CvDbContext db, int userId) =>
            {
                try
                {
                    var skills = db.Users
                        .Include(u => u.Skills)
                        .FirstOrDefault(u => u.Id == userId)?
                        .Skills;

                    if (skills == null) { return Results.NotFound(); }

                    return Results.Ok(skills);
                }
                catch
                {
                    return Results.BadRequest();
                }
            });

            return app;
        }
    }
}