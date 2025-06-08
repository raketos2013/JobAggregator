using JobAggregator.Core.Entities;

namespace JobAggregator.Core.Interfaces.Services;

public interface IRequirementService
{
    Task<Requirement?> GetAsync(int id);
    Task<IEnumerable<Requirement>> GetAllAsync();
    Task<Requirement> CreateAsync(Requirement requirement);
    Task<Requirement> UpdateAsync(Requirement requirement);
    Task<bool> DeleteAsync(int id);
}
