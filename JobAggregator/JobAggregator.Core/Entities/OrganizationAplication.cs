using JobAggregator.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Core.Entities;

public class OrganizationAplication : Entity
{
    [Required]
    public int OrganizationId { get; set; }
    [Required]
    public int ResumeId { get; set; }
    public ApplicationStatus Status { get; set; }
}
