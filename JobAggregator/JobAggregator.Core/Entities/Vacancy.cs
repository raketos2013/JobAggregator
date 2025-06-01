using JobAggregator.Core.Enum;

namespace JobAggregator.Core.Entities;

public class Vacancy : Entity
{
    public int OrganizationId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? Location { get; set; }
    public decimal? Salary { get; set; }
    public ScheduleType ScheduleType { get; set; }
    public int Priority { get; set; }
    public int CountViews { get; set; }
    public int CountResponses { get; set; }
    public DateTime Created { get; set; }
    public List<Requirement>? Requirements { get; set; }
    public List<Responsibility>? Responsibilities { get; set; }
    public List<Offer>? Offers { get; set; }
    public List<Specialisation>? Specialisations { get; set; }
    public List<Skill>? Skills { get; set; }
    public List<UserAplication>? UserAplications { get; set; }
    public List<OrganizationAplication>? OrganizationAplications { get; set; }
}
