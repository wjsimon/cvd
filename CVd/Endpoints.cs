using CVd.Data;
using Microsoft.EntityFrameworkCore;

namespace CVd
{
    public static class Endpoints
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
            app.MapGet("/user/{id}", (CvDbContext db, int id) => 
            {
                try
                {
                    var user = db.Users
                        .Include(u => u.Skills)
                        .Include(u => u.Decorations)
                        .FirstOrDefault(u => u.Id == id);

                    if (user == null) { return Results.NotFound(); }

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

        private static WebApplication MapPost(this WebApplication app)
        {
            app.MapPost("/user", (CvDbContext db, User user) =>
            {
                try
                {
                    db.Users.Add(user);
                    db.SaveChanges();

                    return Results.NoContent();
                }
                catch
                {
                    return Results.BadRequest();
                }
            });

            app.MapPost("/skill", (CvDbContext db, Skill skill) =>
            {
                try
                {
                    db.Skills.Add(skill);
                    db.SaveChanges();

                    return Results.NoContent();
                }
                catch
                {
                    return Results.BadRequest();
                }
            });

            return app;
        }

        private static WebApplication MapDelete(this WebApplication app)
        {
            app.MapDelete("/user/{id}", (CvDbContext db, int id) =>
            {
                if (db.Users.Find(id) is User user)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    return Results.NoContent();
                }

                return Results.NotFound();
            });

            return app;
        }
    }
}