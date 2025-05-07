using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobAggregator.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity>(AppDbContext context)
        : IRepositoryBase<TEntity> where TEntity : Entity
    {
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            if (entity != null)
            {
                context.Set<TEntity>().Remove(entity);
                return await context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetAsync(int id)
        {
           return await context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
