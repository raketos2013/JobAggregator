using JobAggregator.Core.Entities;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Queries;

namespace JobAggregator.Core.Interfaces.Services;

public interface IRoleService
{
    Task<Role> CreateAsync(Role role);
    Task<Role> UpdateAsync(Role role);
    Task<bool> DeleteAsync(int id);
    Task<PagedList<Role>> GetAllAsync(Query query);
    Task<Role?> GetAsync(int id);
    Task<int> GetIdByNameAsync(string name);
}
