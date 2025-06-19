using JobAggregator.Core.Entities;
using JobAggregator.Core.Exceptions;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Interfaces.Services;

namespace JobAggregator.Core.Services;

public class OfferService(IUnitOfWork unitOfWork) : IOfferService
{
    public async Task<Offer?> GetAsync(int id)
    {
        return await unitOfWork.HandbookRepositoryOffer.GetAsync(id);
    }
    public async Task<IEnumerable<Offer>> GetAllAsync()
    {
        return await unitOfWork.HandbookRepositoryOffer.GetAllAsync();
    }
    public async Task<Offer> CreateAsync(Offer offer)
    {
        var created = await unitOfWork.HandbookRepositoryOffer.CreateAsync(offer);
        return await unitOfWork.SaveAsync() > 0 ? created
            : throw new DomainException("Failed to create offer.");
    }
    public async Task<Offer> UpdateAsync(Offer offer)
    {
        var updated = unitOfWork.HandbookRepositoryOffer.Update(offer);
        return await unitOfWork.SaveAsync() > 0 ? updated
            : throw new DomainException("Failed to update offer.");
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await unitOfWork.HandbookRepositoryOffer.DeleteAsync(id);
        return deleted && await unitOfWork.SaveAsync() > 0;
    }
}
