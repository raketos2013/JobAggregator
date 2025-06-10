using JobAggregator.Core.Entities;

namespace JobAggregator.Core.Interfaces.Services;

public interface IActivityService
{
    Task<Activity?> GetAsync(int id);
    Task<IEnumerable<Activity>> GetAllAsync();
    Task<Activity> CreateAsync(Activity activity);
    Task<Activity> UpdateAsync(Activity activity);
    Task<bool> DeleteAsync(int id);
}
