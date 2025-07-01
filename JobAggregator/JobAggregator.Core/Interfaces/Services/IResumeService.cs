using JobAggregator.Core.Entities;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Queries;

namespace JobAggregator.Core.Interfaces.Services;

public interface IResumeService
{
    Task<Resume> CreateAsync(Resume resume);
    Task<Resume> UpdateAsync(Resume resume);
    Task<bool> DeleteAsync(int id);
    Task<PagedList<Resume>> GetAllAsync(Query query);
    Task<Resume?> GetAsync(int id);
}
