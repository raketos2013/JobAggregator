using JobAggregator.Core.Entities;
using JobAggregator.Core.Exceptions;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Interfaces.Services;
using JobAggregator.Core.Queries;

namespace JobAggregator.Core.Services;

public class ActivityService(IUnitOfWork unitOfWork) : IActivityService
{
    public async Task<Activity?> GetAsync(int id)
    {
        return await unitOfWork.HandbookRepositoryActivity.GetAsync(id);
    }
    public async Task<PagedList<Activity>> GetAllAsync(Query query)
    {
        return await unitOfWork.HandbookRepositoryActivity.GetAllAsync(query);
    }
    public async Task<Activity> CreateAsync(Activity activity)
    {
        var created = await unitOfWork.HandbookRepositoryActivity.CreateAsync(activity);
        return await unitOfWork.SaveAsync() > 0 ? created
            : throw new DomainException("Failed to create skill.");
    }
    public async Task<Activity> UpdateAsync(Activity activity)
    {
        var updated = unitOfWork.HandbookRepositoryActivity.Update(activity);
        return await unitOfWork.SaveAsync() > 0 ? updated 
            : throw new DomainException("Failed to update skill.");
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await unitOfWork.HandbookRepositoryActivity.DeleteAsync(id);
        return deleted && await unitOfWork.SaveAsync() > 0;
    }
}
