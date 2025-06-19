using JobAggregator.Core.Entities;
using JobAggregator.Core.Exceptions;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Interfaces.Services;

namespace JobAggregator.Core.Services;

public class SpecialisationService(IUnitOfWork unitOfWork) : ISpecialisationService
{
    public async Task<Specialisation?> GetAsync(int id)
    {
        return await unitOfWork.HandbookRepositorySpecialisation.GetAsync(id);
    }
    public async Task<IEnumerable<Specialisation>> GetAllAsync()
    {
        return await unitOfWork.HandbookRepositorySpecialisation.GetAllAsync();
    }
    public async Task<Specialisation> CreateAsync(Specialisation specialisation)
    {
        var created = await unitOfWork.HandbookRepositorySpecialisation.CreateAsync(specialisation);
        return await unitOfWork.SaveAsync() > 0 ? created
            // TODO: поменять exception на свой
            : throw new DomainException("Failed to create specialisation.");
    }
    public async Task<Specialisation> UpdateAsync(Specialisation specialisation)
    {
        var updated = unitOfWork.HandbookRepositorySpecialisation.Update(specialisation);
        return await unitOfWork.SaveAsync() > 0 ? updated
            // TODO: поменять exception на свой
            : throw new DomainException("Failed to update specialisation.");
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await unitOfWork.HandbookRepositorySpecialisation.DeleteAsync(id);
        return deleted && await unitOfWork.SaveAsync() > 0;
    }
}
