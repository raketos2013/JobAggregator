using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobAggregator.Infrastructure.Repositories;

public class VacancyRepository(AppDbContext context)
    : RepositoryBase<Vacancy>(context), IVacancyRepository
{
    public async Task<List<Vacancy>> GetByOrganizationIdAsync(int organizationId)
    {
        return await context.Vacancies
            .Where(v => v.OrganizationId == organizationId)
            .ToListAsync();
    }
}
