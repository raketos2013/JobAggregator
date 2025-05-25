using JobAggregator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
