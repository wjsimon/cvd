using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVd.Data
{
    public class Project
    {
        [Key] public required string Id { get; set; }
        [ForeignKey("UserId")] public required int UserId { get; set; }

        [NotMapped] public ProjectDescription? Description { get; set; }
    }
}