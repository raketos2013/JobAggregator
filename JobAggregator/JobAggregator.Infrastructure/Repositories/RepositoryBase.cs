using JobAggregator.Core.Entities;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Queries;
using JobAggregator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobAggregator.Infrastructure.Repositories;

public class RepositoryBase<TEntity>(AppDbContext context)
    : IRepositoryBase<TEntity> where TEntity : Entity
{
    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await context.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await GetAsync(id);
        if (entity != null)
        {
            context.Set<TEntity>().Remove(entity);
        }
        return false;
    }

    public async Task<PagedList<TEntity>> GetAllAsync(Query query)
    {
        var entity = context.Set<TEntity>().AsQueryable();
        if (string.IsNullOrEmpty(query.SortColumn))
        {
            query.SortColumn = "Id";
        }
        if (query.IsAscending)
        {
            entity = entity.OrderBy(x => EF.Property<object>(x, query.SortColumn));
        }
        else
        {
            entity = entity.OrderByDescending(x => EF.Property<object>(x, query.SortColumn));
        }
        return await PagedList<TEntity>.ToPagedList(entity, query.Skip, query.Take);
    }

    public async Task<TEntity?> GetAsync(int id)
    {
        return await context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public TEntity Update(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
        return entity;
    }
}
