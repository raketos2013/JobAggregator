using JobAggregator.Core.Entities;

namespace JobAggregator.Core.Interfaces.Repositories;

public interface IHandbookRepository<TEntity> : IRepositoryBase<TEntity>
    where TEntity : Entity, IHandbook
{
}
