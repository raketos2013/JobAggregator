using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Infrastructure.Data;

namespace JobAggregator.Infrastructure.Repositories
{
    public class OrganizationRepository(AppDbContext context) 
        : RepositoryBase<Core.Entities.Organization>(context), IOrganizationRepository
    {

    }
}
