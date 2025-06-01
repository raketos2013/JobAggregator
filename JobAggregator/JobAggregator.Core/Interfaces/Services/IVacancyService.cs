using JobAggregator.Core.Entities;

namespace JobAggregator.Core.Interfaces.Services;

public interface IVacancyService
{
    Task<Vacancy> CreateAsync(Vacancy vacancy);
    Task<Vacancy> UpdateAsync(Vacancy vacancy);
    Task<bool> DeleteAsync(int id);
    Task<List<Vacancy>> GetAllAsync();
    Task<Vacancy?> GetAsync(int id);
    Task<List<Vacancy>> GetByOrganizationIdAsync(int organizationId);
}
