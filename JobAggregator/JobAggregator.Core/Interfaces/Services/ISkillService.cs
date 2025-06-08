using JobAggregator.Core.Entities;

namespace JobAggregator.Core.Interfaces.Services;

public interface ISkillService
{
    Task<Skill?> GetAsync(int id);
    Task<IEnumerable<Skill>> GetAllAsync();
    Task<Skill> CreateAsync(Skill skill);
    Task<Skill> UpdateAsync(Skill skill);
    Task<bool> DeleteAsync(int id);
}
