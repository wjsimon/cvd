using Microsoft.EntityFrameworkCore;

namespace CVd.Database
{
    public partial class CvDbContext : DbContext
    {
        public CvDbContext(DbContextOptions<CvDbContext> options) : base(options) 
        {
            DbPath = Path.Join(
                AppDomain.CurrentDomain.BaseDirectory, 
                "cv.db");
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Milestone> Milestones { get; set; }
        public DbSet<Decoration> Decorations { get; set; }

        public string DbPath { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}