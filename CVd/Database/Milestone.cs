using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVd.Database
{
    public class Milestone
    {
        [Key] public int Id { get; set; }
        [ForeignKey("UserId")] public required int UserId { get; set; }

        public required string Name { get; set; }
        public string? Description { get; set; }
        public required DateOnly Start { get; set; }
        public DateOnly? End { get; set; }
    }
}