using Microsoft.EntityFrameworkCore;

namespace CVd.Data
{
    public partial class CvDbContext : DbContext
    {
        public CvDbContext(DbContextOptions<CvDbContext> options) : this(Program.dbPath, options) { }
        public CvDbContext(string dbpath, DbContextOptions<CvDbContext> options) : base(options)
        {
            DbPath = dbpath;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Milestone> Milestones { get; set; }
        public DbSet<MilestoneDescription> MilestoneDescriptions { get; set; }
        public DbSet<Decoration> Decorations { get; set; }

        public string DbPath { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}