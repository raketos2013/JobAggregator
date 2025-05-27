using JobAggregator.Core.Entities;

namespace JobAggregator.Core.Interfaces.Services
{
    public interface IRoleService
    {
        Task<Role> CreateAsync(Role role);
        Task<Role> UpdateAsync(Role role);
        Task<bool> DeleteAsync(int id);
        Task<List<Role>> GetAllAsync();
        Task<Role?> GetAsync(int id);
        Task<int> GetIdByNameAsync(string name);
    }
}
