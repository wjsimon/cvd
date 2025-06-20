using System.ComponentModel.DataAnnotations;

namespace CVd.Data
{
    public class User
    {
        [Key] public int Id { get; set; }
        public required string Surname { get; set; }
        public required string FamilyName { get; set; }
        public required DateOnly DateOfBirth { get; set; }

        public ICollection<Contact> Contacts { get; set; } = [];
        public ICollection<Milestone> Milestones { get; set; } = [];
        public ICollection<Skill> Skills { get; set; } = [];
        public ICollection<Decoration> Decorations { get; set; } = [];
    }
}