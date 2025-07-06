using JobAggregator.Core.Entities;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Queries;
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

    public async Task<PagedList<Vacancy>> SearchByTermAsync(Query query)
    {
        return await context.Vacancies.SearchByTerm(query.SearchTerm).SortSkipTakeAsync(query);
    }
}
