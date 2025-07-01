using JobAggregator.Core.Entities;
using JobAggregator.Core.Exceptions;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Interfaces.Services;
using JobAggregator.Core.Queries;

namespace JobAggregator.Core.Services;

public class VacancyService(IUnitOfWork unitOfWork) : IVacancyService
{
    public async Task<Vacancy> CreateAsync(Vacancy vacancy)
    {
        _ = await unitOfWork.OrganizationRepository.GetAsync(vacancy.OrganizationId)
                            ?? throw new DomainException($"Organization with ID {vacancy.OrganizationId} not found.");
        vacancy.Created = DateTime.Now;
        var createdVacancy = await unitOfWork.VacancyRepository.CreateAsync(vacancy);
        return await unitOfWork.SaveAsync() > 0 ? createdVacancy
            : throw new DomainException("Failed to create vacancy.");
    }
    public async Task<Vacancy> UpdateAsync(Vacancy vacancy)
    {
        var updatedVacancy = unitOfWork.VacancyRepository.Update(vacancy);
        return await unitOfWork.SaveAsync() > 0 ? updatedVacancy
            : throw new DomainException("Failed to update vacancy.");
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var result = await unitOfWork.VacancyRepository.DeleteAsync(id);

        return result && await unitOfWork.SaveAsync() > 0;
    }
    public async Task<PagedList<Vacancy>> GetAllAsync(Query query)
    {

        return await unitOfWork.VacancyRepository.GetAllAsync(query);
    }
    public async Task<Vacancy?> GetAsync(int id)
    {
        return await unitOfWork.VacancyRepository.GetAsync(id);
    }
    public async Task<List<Vacancy>> GetByOrganizationIdAsync(int organizationId)
    {
        return await unitOfWork.VacancyRepository.GetByOrganizationIdAsync(organizationId);
    }
}
