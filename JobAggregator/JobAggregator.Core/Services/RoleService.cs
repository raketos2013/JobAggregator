using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Interfaces.Services;

namespace JobAggregator.Core.Services
{
    public class RoleService(IRoleRepository roleRepository) : IRoleService
    {
        public async Task<Role> CreateAsync(Role role)
        {
            return await roleRepository.CreateAsync(role);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await roleRepository.DeleteAsync(id);
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await roleRepository.GetAllAsync();
        }

        public async Task<Role> GetAsync(int id)
        {
            return await roleRepository.GetAsync(id);
        }

        public async Task<int> GetIdByNameAsync(string name)
        {
            return await roleRepository.GetIdByNameAsync(name);
        }

        public async Task<Role> UpdateAsync(Role role)
        {
            return await roleRepository.UpdateAsync(role);
        }
    }
}
