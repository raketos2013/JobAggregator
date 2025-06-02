using JobAggregator.Core.Enum;

namespace JobAggregator.Core.Entities;

public class UserAplication : Entity
{
    public int UserId { get; set; }
    public int VacancyId { get; set; }
    public ApplicationStatus Status { get; set; }
}
