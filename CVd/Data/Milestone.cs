using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVd.Data
{
    public class Milestone
    {
        [Key] public int Id { get; set; }
        [ForeignKey("UserId")] public required int UserId { get; set; }
        [ForeignKey("DescriptionId")] public int DescriptionId { get; set; }

        public required string Name { get; set; }
        public required DateOnly Start { get; set; }
        public DateOnly? End { get; set; }
    }
}