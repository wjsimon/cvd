using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVd.Data
{
    public partial class Milestone
    {
        [Key] public required string Id { get; set; }
        [ForeignKey("UserId")] public required int UserId { get; set; }
        
        public required string DescriptionId { get; set; } //not a foreign key; aggregated at runtime based on languagecode
        public required DateOnly Start { get; set; }
        public DateOption StartOption { get; set; } = 0;
        public DateOnly? End { get; set; }
        public DateOption? EndOption { get; set; } = 0;

        [NotMapped] public MilestoneDescription? Description { get; set; } //can only be mapped at runtime
    }
}