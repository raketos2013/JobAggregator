using JobAggregator.Core.Entities;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Queries;

namespace JobAggregator.Core.Interfaces.Services;

public interface ISkillService
{
    Task<Skill?> GetAsync(int id);
    Task<PagedList<Skill>> GetAllAsync(Query query);
    Task<Skill> CreateAsync(Skill skill);
    Task<Skill> UpdateAsync(Skill skill);
    Task<bool> DeleteAsync(int id);
}
