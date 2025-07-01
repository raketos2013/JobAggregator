using JobAggregator.Core.Entities;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Queries;

namespace JobAggregator.Core.Interfaces.Services;

public interface ISpecialisationService
{
    Task<Specialisation?> GetAsync(int id);
    Task<PagedList<Specialisation>> GetAllAsync(Query query);
    Task<Specialisation> CreateAsync(Specialisation specialisation);
    Task<Specialisation> UpdateAsync(Specialisation specialisation);
    Task<bool> DeleteAsync(int id);
}
