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
                WrapHandler((CvDbContext db, int id, string lang) =>
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
                });
            });

            if (mapAdditional)
            {
                app.MapAdditional();
            }
        }

        private static IResult WrapHandler(Delegate handler)
        {
            try
            {
                var result = handler.DynamicInvoke();
                if (result != null)
                {
                    return (IResult)result;
                }
                else
                {
                    return Results.NoContent();
                }
            }
#if DEBUG
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
#else
            catch
            {
                return Results.BadRequest(ex);
            }
#endif
        }
    }
}