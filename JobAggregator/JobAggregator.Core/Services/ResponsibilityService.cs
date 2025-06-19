using JobAggregator.Core.Entities;
using JobAggregator.Core.Exceptions;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Interfaces.Services;

namespace JobAggregator.Core.Services;

public class ResponsibilityService(IUnitOfWork unitOfWork) : IResponsibilityService
{
    public async Task<Responsibility?> GetAsync(int id)
    {
        return await unitOfWork.HandbookRepositoryResponsibility.GetAsync(id);
    }

    public async Task<IEnumerable<Responsibility>> GetAllAsync()
    {
        return await unitOfWork.HandbookRepositoryResponsibility.GetAllAsync();
    }

    public async Task<Responsibility> CreateAsync(Responsibility responsibility)
    {
        var created = await unitOfWork.HandbookRepositoryResponsibility.CreateAsync(responsibility);
        return await unitOfWork.SaveAsync() > 0 ? created
            : throw new DomainException("Failed to create responsibility.");
    }

    public async Task<Responsibility> UpdateAsync(Responsibility responsibility)
    {
        var updated = unitOfWork.HandbookRepositoryResponsibility.Update(responsibility);
        return await unitOfWork.SaveAsync() > 0 ? updated
            : throw new DomainException("Failed to update responsibility.");
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await unitOfWork.HandbookRepositoryResponsibility.DeleteAsync(id);
        return deleted && await unitOfWork.SaveAsync() > 0;
    }
}
