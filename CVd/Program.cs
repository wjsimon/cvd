using CVd.Data;

namespace CVd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EnsureDatabaseExists();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddDbContext<CvDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseHttpsRedirection().UseAuthorization();

#if DEBUG
            Endpoints.Configure(app, includeMutations: true);
#else
            Endpoints.Configure(app);
#endif

            app.Run();
        }

        private static void EnsureDatabaseExists()
        {
            var path = Path.Join(
                AppDomain.CurrentDomain.BaseDirectory,
                "cv.db");

            while (!File.Exists(path))
            {
                Console.WriteLine($"No database found at {path}! Please add the database, then press any key to re-try.");
                Console.ReadKey();
            }
        }
    }
}