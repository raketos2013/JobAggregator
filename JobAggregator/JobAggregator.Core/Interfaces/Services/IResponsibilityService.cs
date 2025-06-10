using JobAggregator.Core.Entities;

namespace JobAggregator.Core.Interfaces.Services;

public interface IResponsibilityService
{
    Task<Responsibility?> GetAsync(int id);
    Task<IEnumerable<Responsibility>> GetAllAsync();
    Task<Responsibility> CreateAsync(Responsibility responsibility);
    Task<Responsibility> UpdateAsync(Responsibility responsibility);
    Task<bool> DeleteAsync(int id);
}
