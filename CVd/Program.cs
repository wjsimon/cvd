using CVd.Database;

namespace CVd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddDbContext<CvDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseHttpsRedirection().UseAuthorization();
            app.MapGet("/user/{id}", (CvDbContext db, int id) => {
                
                if (db.Users.Find(id) is CvDbContext.User user)
                {
                    return Results.Ok(user);
                }

                return Results.NotFound();
            });

            app.MapPost("/user", (CvDbContext db, CvDbContext.User user) =>
            {
                db.Users.Add(user);
                db.SaveChanges();
            });

            app.MapDelete("/user/{id}", (CvDbContext db, int id) =>
            {
                if (db.Users.Find(id) is CvDbContext.User user)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    return Results.NoContent();
                }

                return Results.NotFound();
            });

            app.Run();
        }
    }
}