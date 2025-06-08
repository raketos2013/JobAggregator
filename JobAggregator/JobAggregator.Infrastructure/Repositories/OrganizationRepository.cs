using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Infrastructure.Data;

namespace JobAggregator.Infrastructure.Repositories;

public class OrganizationRepository(AppDbContext context)
    : RepositoryBase<Organization>(context), IOrganizationRepository
{

}
