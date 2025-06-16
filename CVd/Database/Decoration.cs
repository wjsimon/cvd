using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVd.Database
{
    public class Decoration
    {
        [Key] public int Id { get; set; }
        [ForeignKey("UserId")] public required int UserId { get; set; }

        public required string Value { get; set; }
    }
}