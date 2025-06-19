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
    public List<HandbookDTO>? Requirements { get; set; }
    public List<HandbookDTO>? Responsibilities { get; set; }
    public List<HandbookDTO>? Offers { get; set; }
    public List<HandbookDTO>? Specialisations { get; set; }
    public List<HandbookDTO>? Skills { get; set; }
}
