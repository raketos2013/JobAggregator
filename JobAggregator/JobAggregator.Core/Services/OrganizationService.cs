using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Interfaces.Services;

namespace JobAggregator.Core.Services
{
    public class OrganizationService(IOrganizationRepository organizationRepository) 
        : IOrganizationService
    {
        public async Task<bool> DeleteAsync(int id)
        {
            return await organizationRepository.DeleteAsync(id);
        }
        public async Task<Organization> CreateAsync(Organization organization)
        {
            return await organizationRepository.CreateAsync(organization);
        }
        public async Task<Organization> UpdateAsync(Organization organization)
        {
            return await organizationRepository.UpdateAsync(organization);
        }
        public async Task<IEnumerable<Organization>> GetAllAsync()
        {
            return await organizationRepository.GetAllAsync();
        }
        public async Task<Organization?> GetAsync(int id)
        {
            return await organizationRepository.GetAsync(id);
        }
    }
}
