using JobAggregator.Core.Entities;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Queries;

namespace JobAggregator.Core.Interfaces.Services;

public interface IOfferService
{
    Task<Offer?> GetAsync(int id);
    Task<PagedList<Offer>> GetAllAsync(Query query);
    Task<Offer> CreateAsync(Offer offer);
    Task<Offer> UpdateAsync(Offer offer);
    Task<bool> DeleteAsync(int id);
}
