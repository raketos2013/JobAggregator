using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Infrastructure.Data;

namespace JobAggregator.Infrastructure.Repositories;

public class UserRepository(AppDbContext context)
    : RepositoryBase<User>(context), IUserRepository
{

}
