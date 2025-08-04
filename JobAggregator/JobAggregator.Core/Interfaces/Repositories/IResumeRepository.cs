using JobAggregator.Core.Entities;

namespace JobAggregator.Core.Interfaces.Repositories;

public interface IResumeRepository : IRepositoryBase<Resume>
{
    new Task<Resume?> GetAsync(int id);
    Task<List<Resume>> GetResumesByUserIdAsync(int id);
}
