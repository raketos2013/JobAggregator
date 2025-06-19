using JobAggregator.Core.Entities;
using JobAggregator.Core.Exceptions;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Interfaces.Services;

namespace JobAggregator.Core.Services;

public class ResumeService(IUnitOfWork unitOfWork) : IResumeService
{
    public async Task<Resume> CreateAsync(Resume resume)
    {
        var createdResume = await unitOfWork.ResumeRepository.CreateAsync(resume);
        return await unitOfWork.SaveAsync() > 0 ? createdResume
            : throw new DomainException("Failed to create resume.");
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await unitOfWork.ResumeRepository.DeleteAsync(id);
        return deleted && await unitOfWork.SaveAsync() > 0;
    }
    public Task<List<Resume>> GetAllAsync()
    {
        return unitOfWork.ResumeRepository.GetAllAsync();
    }
    public Task<Resume?> GetAsync(int id)
    {
        return unitOfWork.ResumeRepository.GetAsync(id);
    }
    public async Task<Resume> UpdateAsync(Resume resume)
    {
        var updatedResume = unitOfWork.ResumeRepository.Update(resume);
        return await unitOfWork.SaveAsync() > 0 ? updatedResume
            : throw new DomainException("Failed to update resume.");
    }
}
