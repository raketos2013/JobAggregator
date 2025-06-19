using JobAggregator.Core.Entities;
using JobAggregator.Core.Enum;

namespace JobAggregator.Api.DTO;

public class VacancyDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string? Location { get; set; }
    public decimal? Salary { get; set; }
    public int OrganizationId { get; set; }
    public ScheduleType ScheduleType { get; set; }
    public List<Requirement>? Requirements { get; set; }
    public List<Responsibility>? Responsibilities { get; set; }
    public List<Offer>? Offers { get; set; }
    public List<Specialisation>? Specialisations { get; set; }
    public List<Skill>? Skills { get; set; }
}
