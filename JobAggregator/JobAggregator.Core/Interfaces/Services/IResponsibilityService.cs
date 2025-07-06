using JobAggregator.Core.Entities;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Queries;

namespace JobAggregator.Core.Interfaces.Services;

public interface IResponsibilityService
{
    Task<Responsibility?> GetAsync(int id);
    Task<PagedList<Responsibility>> GetAllAsync(Query query);
    Task<Responsibility> CreateAsync(Responsibility responsibility);
    Task<Responsibility> UpdateAsync(Responsibility responsibility);
    Task<bool> DeleteAsync(int id);
}
