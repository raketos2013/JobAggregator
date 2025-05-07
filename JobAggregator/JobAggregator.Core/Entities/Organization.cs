using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Core.Entities
{
    public class Organization : Entity
    {
        [Required]
        public string Name { get; set; }
        public string? Website { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public int? PhoneNumber { get; set; }
        public string? Address { get; set; }
        [Required]
        public List<User> Users { get; set; }
        public List<Activity>? Activities { get; set; }
        public List<Vacancy>? Vacancies { get; set; }
        public List<OrganizationAplication>? OrganizationAplications { get; set; }
    }
}
