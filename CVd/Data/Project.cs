using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVd.Data
{
    public class Project
    {
        [Key] public required string Id { get; set; }
        [ForeignKey("UserId")] public required int UserId { get; set; }

        public string? Link { get; set; }
        public int? SortOrder { get; set; }
        public string? TagsString { get; set; }

        [NotMapped] public ProjectDescription? Description { get; set; }
        [NotMapped] public List<string> Tags => TagsString?.Split(',').ToList() ?? [];
    }
}