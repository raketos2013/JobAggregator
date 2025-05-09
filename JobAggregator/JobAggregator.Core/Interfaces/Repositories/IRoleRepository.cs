using JobAggregator.Core.Entities;

namespace JobAggregator.Core.Interfaces.Repositories
{
    public interface IRoleRepository : IRepositoryBase<Role>
    {
        Task<int> GetIdByNameAsync(string name);
    }
}
