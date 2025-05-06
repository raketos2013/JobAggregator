using JobAggregator.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Core.Entities
{
    public class UserAplication
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int VacancyId { get; set; }
        public ApplicationStatuse Statuse { get; set; }
    }
}
