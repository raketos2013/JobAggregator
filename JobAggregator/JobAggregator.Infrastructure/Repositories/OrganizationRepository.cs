using JobAggregator.Core.Entities;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Queries;
using JobAggregator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobAggregator.Infrastructure.Repositories;

public class OrganizationRepository(AppDbContext context)
    : RepositoryBase<Organization>(context), IOrganizationRepository
{
    public async Task<List<Organization>> GetByUserIdAsync(int id)
    {
        return await context.Organizations.Where(x => x.Users.Any(z => z.Id == id)).ToListAsync();
    }

    public async Task<Organization> GetWithUserAsync(int id)
    {
        return await context.Organizations.Include(v => v.Users)
                                            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<PagedList<Organization>> SearchByTermAsync(Query query)
    {
        return await context.Organizations.SearchByTerm(query.SearchTerm).SortSkipTakeAsync(query);
    }
}
