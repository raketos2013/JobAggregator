using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Interfaces.Services;

namespace JobAggregator.Core.Services;

public class RequirementService(IUnitOfWork unitOfWork) : IRequirementService
{
    public async Task<Requirement?> GetAsync(int id)
    {
        return await unitOfWork.HandbookRepositoryRequirement.GetAsync(id);
    }
    public async Task<IEnumerable<Requirement>> GetAllAsync()
    {
        return await unitOfWork.HandbookRepositoryRequirement.GetAllAsync();
    }
    public async Task<Requirement> CreateAsync(Requirement requirement)
    {
        var created = await unitOfWork.HandbookRepositoryRequirement.CreateAsync(requirement);
        return await unitOfWork.SaveAsync() > 0 ? created
            // TODO: поменять exception на свой
            : throw new Exception("Failed to create requirement.");
    }
    public async Task<Requirement> UpdateAsync(Requirement requirement)
    {
        var updated = unitOfWork.HandbookRepositoryRequirement.Update(requirement);
        return await unitOfWork.SaveAsync() > 0 ? updated :
            // TODO: поменять exception на свой
            throw new Exception("Failed to update requirement.");
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await unitOfWork.HandbookRepositoryRequirement.DeleteAsync(id);
        return deleted && await unitOfWork.SaveAsync() > 0;
    }
}
