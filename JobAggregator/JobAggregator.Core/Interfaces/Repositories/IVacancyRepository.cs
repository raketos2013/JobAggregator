using JobAggregator.Core.Entities;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Queries;

namespace JobAggregator.Core.Interfaces.Repositories;

public interface IVacancyRepository : IRepositoryBase<Vacancy>
{
    Task<List<Vacancy>> GetByOrganizationIdAsync(int organizationId);
    Task<PagedList<Vacancy>> SearchByTermAsync(Query query);
    new Task<Vacancy?> GetAsync(int id);
}
