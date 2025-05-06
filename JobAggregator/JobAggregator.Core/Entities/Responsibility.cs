using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Core.Entities
{
    public class Responsibility
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int VacancyId { get; set; }
    }
}
