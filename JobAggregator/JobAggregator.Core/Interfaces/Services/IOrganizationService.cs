using JobAggregator.Core.Entities;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Queries;

namespace JobAggregator.Core.Interfaces.Services;

public interface IOrganizationService
{
    Task<Organization?> GetAsync(int id);
    Task<PagedList<Organization>> GetAllAsync(Query query);
    Task<Organization> CreateAsync(Organization organization, int userId);
    Task<Organization> UpdateAsync(Organization organization);
    Task<bool> DeleteAsync(int id);
    Task<Organization> GetWithUserAsync(int id);
    Task<List<Organization>> GetByUserIdAsync(int id);

}
