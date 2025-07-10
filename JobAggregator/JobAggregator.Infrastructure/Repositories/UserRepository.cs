using JobAggregator.Core.Entities;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Queries;
using JobAggregator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobAggregator.Infrastructure.Repositories;

public class UserRepository(AppDbContext context)
    : RepositoryBase<User>(context), IUserRepository
{
    public async Task<User?> GetByLoginAsync(string login)
    {
        return await context.Users.FirstOrDefaultAsync(x => x.Login == login);
    }

    public async Task<PagedList<User>> SearchByTermAsync(Query query)
    {
        return await context.Users.SearchByTerm(query.SearchTerm).SortSkipTakeAsync(query);
    }
}
