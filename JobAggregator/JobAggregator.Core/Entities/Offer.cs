using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Core.Entities
{
    public class Offer : Entity
    {
        [Required]
        public string Name { get; set; }
        public int VacancyId { get; set; }
    }
}
