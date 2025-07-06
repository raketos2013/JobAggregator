using JobAggregator.Core.Entities;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Queries;

namespace JobAggregator.Core.Interfaces.Services;

public interface IActivityService
{
    Task<Activity?> GetAsync(int id);
    Task<PagedList<Activity>> GetAllAsync(Query query);
    Task<Activity> CreateAsync(Activity activity);
    Task<Activity> UpdateAsync(Activity activity);
    Task<bool> DeleteAsync(int id);
}
