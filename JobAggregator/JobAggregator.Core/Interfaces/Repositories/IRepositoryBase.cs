using JobAggregator.Core.Entities;

namespace JobAggregator.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        Task<TEntity> CreateAsync(TEntity entity);
        TEntity Update(TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<TEntity?> GetAsync(int id);
        Task<List<TEntity>> GetAllAsync();
    }
}
