using JobAggregator.Core.Entities;

namespace JobAggregator.Core.Interfaces.Services;

public interface IOfferService
{
    Task<Offer?> GetAsync(int id);
    Task<IEnumerable<Offer>> GetAllAsync();
    Task<Offer> CreateAsync(Offer offer);
    Task<Offer> UpdateAsync(Offer offer);
    Task<bool> DeleteAsync(int id);
}
