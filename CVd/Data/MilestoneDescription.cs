using Microsoft.EntityFrameworkCore;

namespace CVd.Data
{
    [PrimaryKey(nameof(DescriptionId), nameof(LanguageCode))]
    public class MilestoneDescription
    {
        public int DescriptionId { get; set; }
        public required string LanguageCode { get; set; }
        public string? Value { get; set; }
    }
}
