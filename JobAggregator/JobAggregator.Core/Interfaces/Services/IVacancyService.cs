using JobAggregator.Core.Entities;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Queries;

namespace JobAggregator.Core.Interfaces.Services;

public interface IVacancyService
{
    Task<Vacancy> CreateAsync(Vacancy vacancy);
    Task<Vacancy> UpdateAsync(Vacancy vacancy);
    Task<bool> DeleteAsync(int id);
    Task<PagedList<Vacancy>> GetAllAsync(Query query);
    Task<Vacancy?> GetAsync(int id);
    Task<List<Vacancy>> GetByOrganizationIdAsync(int organizationId);
}
