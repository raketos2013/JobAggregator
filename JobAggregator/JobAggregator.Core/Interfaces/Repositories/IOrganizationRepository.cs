using JobAggregator.Core.Entities;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Queries;

namespace JobAggregator.Core.Interfaces.Repositories;

public interface IOrganizationRepository : IRepositoryBase<Organization>
{
    Task<PagedList<Organization>> SearchByTermAsync(Query query);
    Task<Organization> GetWithUserAsync(int id);
    Task<List<Organization>> GetByUserIdAsync(int id);
}
