using JobAggregator.Core.Entities;

namespace JobAggregator.Api.DTO;

public class OrganizationUsersDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? Website { get; set; }
    public string Email { get; set; }
    public int? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public List<int> IdUsers { get; set; } = [];
    public List<Activity>? Activities { get; set; }
}
