using JobAggregator.Core.Entities;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Queries;
//using X.PagedList;

namespace JobAggregator.Core.Interfaces.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : Entity
{
    Task<TEntity> CreateAsync(TEntity entity);
    TEntity Update(TEntity entity);
    Task<bool> DeleteAsync(int id);
    Task<TEntity?> GetAsync(int id);
    Task<PagedList<TEntity>> GetAllAsync(Query query);
}
