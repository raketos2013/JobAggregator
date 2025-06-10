using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Infrastructure.Data;

namespace JobAggregator.Infrastructure.Repositories;

public class HandBookRepository<TEntity>(AppDbContext context)
    : RepositoryBase<TEntity>(context), IHandbookRepository<TEntity>
    where TEntity : Entity, IHandbook
{

}
