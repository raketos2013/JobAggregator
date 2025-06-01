using JobAggregator.Core.Entities;

namespace JobAggregator.Core.Interfaces.Repositories;

public interface IVacancyRepository : IRepositoryBase<Vacancy>
{
    Task<List<Vacancy>> GetByOrganizationIdAsync(int organizationId);
}
