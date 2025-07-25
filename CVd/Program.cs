using CVd.Data;

namespace CVd
{
    public class Program
    {
        public static readonly string dbPath = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "cv.db");

        public static void Main(string[] args)
        {
            EnsureDatabaseExists();

            var builder = WebApplication.CreateBuilder(args);
            builder.Services
                .AddDbContext<CvDbContext>()
                .AddCors(options =>
                {
                    options.AddDefaultPolicy(builder =>
                    {
                        builder.SetIsOriginAllowed(origin => OriginAllowed(origin));
                    });
                });

            var app = builder.Build();
            app.UseCors();
#if DEBUG
            Endpoints.Configure(app, mapAdditional: true);
#else
            Endpoints.Configure(app);
#endif
            app.Run();
        }

        private static void EnsureDatabaseExists()
        {
            while (!File.Exists(dbPath))
            {
                Console.WriteLine($"No database found at {dbPath}! Please add the database, then press any key to re-try.");
                Console.ReadKey();
            }
        }

        private static bool OriginAllowed(string origin)
        {
            return origin.Contains("localhost") || origin.Contains("dev.local");
        }
    }
}