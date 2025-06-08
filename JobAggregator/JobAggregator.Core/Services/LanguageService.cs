using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Interfaces.Services;

namespace JobAggregator.Core.Services;

public class LanguageService(IUnitOfWork unitOfWork) : ILanguageService
{
    public async Task<Language?> GetAsync(int id)
    {
        return await unitOfWork.LanguageRepository.GetAsync(id);
    }
    public async Task<IEnumerable<Language>> GetAllAsync()
    {
        return await unitOfWork.LanguageRepository.GetAllAsync();
    }
    public async Task<Language> CreateAsync(Language language)
    {
        var created = await unitOfWork.LanguageRepository.CreateAsync(language);
        return await unitOfWork.SaveAsync() > 0 ? created
            // TODO: поменять exception на свой
            : throw new Exception("Failed to create language.");
    }
    public async Task<Language> UpdateAsync(Language language)
    {
        var updated = unitOfWork.LanguageRepository.Update(language);
        return await unitOfWork.SaveAsync() > 0 ? updated
            // TODO: поменять exception на свой
            : throw new Exception("Failed to update language.");
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await unitOfWork.LanguageRepository.DeleteAsync(id);
        return deleted && await unitOfWork.SaveAsync() > 0;
    }
    public async Task<Language?> GetByNameAsync(string name)
    {
        return await unitOfWork.LanguageRepository.GetByNameAsync(name);
    }
    public async Task<Language?> GetByCodeAsync(string code)
    {
        return await unitOfWork.LanguageRepository.GetByCodeAsync(code);
    }
}
