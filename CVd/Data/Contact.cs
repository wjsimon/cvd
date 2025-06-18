using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVd.Data
{
    public partial class Contact
    {
        [Key] public int Id { get; set; }
        [ForeignKey("UserId")] public required int UserId { get; set; }

        public required string Descriptor { get; set; }
        public required string Value { get; set; }
        public required ContactType Type { get; set; }
    }

    public enum ContactType
    {
        Free = 0,
        Url,
        Email,
    }
}
