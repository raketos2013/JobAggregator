using JobAggregator.Core.Entities;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Queries;

namespace JobAggregator.Core.Interfaces.Repositories;

public interface IUserRepository : IRepositoryBase<User>
{
    Task<PagedList<User>> SearchByTermAsync(Query query);
    Task<User?> GetByLoginAsync(string login);
    Task<User?> GetVacanciesAsync(int id);
}
