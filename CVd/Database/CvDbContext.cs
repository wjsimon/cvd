using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CVd.Database
{
    public class CvDbContext : DbContext
    {
        public CvDbContext(DbContextOptions<CvDbContext> options) : base(options) 
        {
            DbPath = Path.Join(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                "cv.db");
        }
        
        public DbSet<User> Users { get; set; }
        public string DbPath { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        public class User
        {
            [Key] public int Id { get; set; }
            public required string Surname { get; set; }
            public required string FamilyName { get; set; }
        }
    }
}
