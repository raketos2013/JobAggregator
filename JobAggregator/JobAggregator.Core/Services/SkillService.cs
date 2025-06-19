using JobAggregator.Core.Entities;
using JobAggregator.Core.Exceptions;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Interfaces.Services;

namespace JobAggregator.Core.Services;

public class SkillService(IUnitOfWork unitOfWork) : ISkillService
{
    public async Task<Skill?> GetAsync(int id)
    {
        return await unitOfWork.HandbookRepositorySkill.GetAsync(id);
    }
    public async Task<IEnumerable<Skill>> GetAllAsync()
    {
        return await unitOfWork.HandbookRepositorySkill.GetAllAsync();
    }
    public async Task<Skill> CreateAsync(Skill skill)
    {
        var created = await unitOfWork.HandbookRepositorySkill.CreateAsync(skill);
        return await unitOfWork.SaveAsync() > 0 ? created
            : throw new DomainException("Failed to create skill.");
    }
    public async Task<Skill> UpdateAsync(Skill skill)
    {
        var updated = unitOfWork.HandbookRepositorySkill.Update(skill);
        return await unitOfWork.SaveAsync() > 0 ? updated
            : throw new DomainException("Failed to update skill.");
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await unitOfWork.HandbookRepositorySkill.DeleteAsync(id);
        return deleted && await unitOfWork.SaveAsync() > 0;
    }
}
