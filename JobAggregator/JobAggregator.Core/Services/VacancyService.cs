using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Interfaces.Services;

namespace JobAggregator.Core.Services;

public class VacancyService(IUnitOfWork unitOfWork) : IVacancyService
{
    public async Task<Vacancy> CreateAsync(Vacancy vacancy)
    {
        _ = await unitOfWork.OrganizationRepository.GetAsync(vacancy.OrganizationId)
                            // TODO: поменять exception на свой
                            ?? throw new Exception($"Organization with ID {vacancy.OrganizationId} not found.");
        vacancy.Created = DateTime.Now;
        var createdVacancy = await unitOfWork.VacancyRepository.CreateAsync(vacancy);
        return await unitOfWork.SaveAsync() > 0 ? createdVacancy
            // TODO: поменять exception на свой
            : throw new Exception("Failed to create vacancy.");
    }
    public async Task<Vacancy> UpdateAsync(Vacancy vacancy)
    {
        var updatedVacancy = unitOfWork.VacancyRepository.Update(vacancy);
        return await unitOfWork.SaveAsync() > 0 ? updatedVacancy 
            // TODO: поменять exception на свой
            : throw new Exception("Failed to update vacancy.");
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var result = await unitOfWork.VacancyRepository.DeleteAsync(id);

        return result && await unitOfWork.SaveAsync() > 0;
    }
    public async Task<List<Vacancy>> GetAllAsync()
    {
        return await unitOfWork.VacancyRepository.GetAllAsync();
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
