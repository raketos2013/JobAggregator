using JobAggregator.Core.Entities;
using JobAggregator.Core.Exceptions;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Interfaces.Services;
using JobAggregator.Core.Queries;

namespace JobAggregator.Core.Services;

public class OrganizationService(IUnitOfWork unitOfWork)
    : IOrganizationService
{
    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await unitOfWork.OrganizationRepository.DeleteAsync(id);
        return deleted && await unitOfWork.SaveAsync() > 0;
    }
    public async Task<Organization> CreateAsync(Organization organization)
    {
        var createdOrganization = await unitOfWork.OrganizationRepository.CreateAsync(organization);
        return await unitOfWork.SaveAsync() > 0 ? createdOrganization
            : throw new DomainException("Failed to create organization.");
    }
    public async Task<Organization> UpdateAsync(Organization organization)
    {
        var updatedOrganization = unitOfWork.OrganizationRepository.Update(organization);
        return await unitOfWork.SaveAsync() > 0 ? updatedOrganization
            : throw new DomainException("Failed to update organization.");
    }
    public async Task<PagedList<Organization>> GetAllAsync(Query query)
    {
        return await unitOfWork.OrganizationRepository.GetAllAsync(query);
    }
    public async Task<Organization?> GetAsync(int id)
    {
        return await unitOfWork.OrganizationRepository.GetAsync(id);
    }
}
