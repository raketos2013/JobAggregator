using JobAggregator.Core.Entities;

namespace JobAggregator.Core.Interfaces.Services
{
    public interface IOrganizationService
    {
        Task<Organization?> GetAsync(int id);
        Task<IEnumerable<Organization>> GetAllAsync();
        Task<Organization> CreateAsync(Organization organization);
        Task<Organization> UpdateAsync(Organization organization);
        Task<bool> DeleteAsync(int id);
    }
}
