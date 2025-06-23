using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVd.Data
{
    public partial class Skill
    {
        [Key] public required string Id { get; set; }
        [ForeignKey("UserId")] public required int UserId { get; set; }

        public string? DisplayValue { get; set; } //if unused, Id can be
        public SkillCategory Category { get; set; }
        public string? Style { get; set; }
        public int? SortOrder {  get; set; }
        public string? LanguageCode { get; set; }
    }
}