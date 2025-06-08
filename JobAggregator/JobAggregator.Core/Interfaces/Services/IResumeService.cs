using JobAggregator.Core.Entities;

namespace JobAggregator.Core.Interfaces.Services;

public interface IResumeService
{
    Task<Resume> CreateAsync(Resume resume);
    Task<Resume> UpdateAsync(Resume resume);
    Task<bool> DeleteAsync(int id);
    Task<List<Resume>> GetAllAsync();
    Task<Resume?> GetAsync(int id);
}
