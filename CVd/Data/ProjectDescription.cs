using Microsoft.EntityFrameworkCore;

namespace CVd.Data
{
    [PrimaryKey(nameof(DescriptionId), nameof(LanguageCode))]
    public class ProjectDescription
    {
        public required string DescriptionId { get; set; }
        public required string LanguageCode { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
    }
}