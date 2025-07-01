using JobAggregator.Core.Entities;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Queries;

namespace JobAggregator.Core.Interfaces.Services;

public interface IRequirementService
{
    Task<Requirement?> GetAsync(int id);
    Task<PagedList<Requirement>> GetAllAsync(Query query);
    Task<Requirement> CreateAsync(Requirement requirement);
    Task<Requirement> UpdateAsync(Requirement requirement);
    Task<bool> DeleteAsync(int id);
}
