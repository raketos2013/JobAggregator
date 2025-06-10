using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Interfaces.Services;

namespace JobAggregator.Core.Services;

public class ActivityService(IUnitOfWork unitOfWork) : IActivityService
{
    public async Task<Activity?> GetAsync(int id)
    {
        return await unitOfWork.HandbookRepositoryActivity.GetAsync(id);
    }
    public async Task<IEnumerable<Activity>> GetAllAsync()
    {
        return await unitOfWork.HandbookRepositoryActivity.GetAllAsync();
    }
    public async Task<Activity> CreateAsync(Activity activity)
    {
        var created = await unitOfWork.HandbookRepositoryActivity.CreateAsync(activity);
        return await unitOfWork.SaveAsync() > 0 ? created
            // TODO: поменять exception на свой
            : throw new Exception("Failed to create skill.");
    }
    public async Task<Activity> UpdateAsync(Activity activity)
    {
        var updated = unitOfWork.HandbookRepositoryActivity.Update(activity);
        return await unitOfWork.SaveAsync() > 0 ? updated
            // TODO: поменять exception на свой
            : throw new Exception("Failed to update skill.");
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await unitOfWork.HandbookRepositoryActivity.DeleteAsync(id);
        return deleted && await unitOfWork.SaveAsync() > 0;
    }
}
