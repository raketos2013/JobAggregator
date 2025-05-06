using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Core.Entities
{
    public class Requirement
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int VacancyId { get; set; }
    }
}
