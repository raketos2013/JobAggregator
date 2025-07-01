using JobAggregator.Core.Entities;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Queries;
using JobAggregator.Infrastructure.Data;

namespace JobAggregator.Infrastructure.Repositories;

public class OrganizationRepository(AppDbContext context)
    : RepositoryBase<Organization>(context), IOrganizationRepository
{
    public async Task<PagedList<Organization>> SearchByTermAsync(Query query)
    {
        return await context.Organizations.SearchByTerm(query.SearchTerm).SortSkipTakeAsync(query);
    }
}
