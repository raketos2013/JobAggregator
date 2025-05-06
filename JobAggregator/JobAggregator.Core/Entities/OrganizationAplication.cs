using JobAggregator.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Core.Entities
{
    public class OrganizationAplication
    {
        public int Id { get; set; }
        [Required]
        public int OrganizationId { get; set; }
        [Required]
        public int ResumeId { get; set; }
        public ApplicationStatuse Statuse { get; set; }
    }
}
