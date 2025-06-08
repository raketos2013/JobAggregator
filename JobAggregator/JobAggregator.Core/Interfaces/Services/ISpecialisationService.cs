using JobAggregator.Core.Entities;

namespace JobAggregator.Core.Interfaces.Services;

public interface ISpecialisationService
{
    Task<Specialisation?> GetAsync(int id);
    Task<IEnumerable<Specialisation>> GetAllAsync();
    Task<Specialisation> CreateAsync(Specialisation specialisation);
    Task<Specialisation> UpdateAsync(Specialisation specialisation);
    Task<bool> DeleteAsync(int id);
}
