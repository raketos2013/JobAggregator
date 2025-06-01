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
    // TODO: добавить DTO для Requirements, Responsibilities, Offers, Specialisations, Skills
}
