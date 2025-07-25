﻿using Microsoft.EntityFrameworkCore;

namespace CVd.Data
{
    [PrimaryKey(nameof(DescriptionId), nameof(LanguageCode))]
    public class MilestoneDescription
    {
        public required string DescriptionId { get; set; }
        public required string LanguageCode { get; set; }
        public required string Row1 { get; set; }
        public string? Row2 { get; set; }
        public string? Description { get; set; }
        public string? DisplayTag { get; set; }
    }
}