using JobAggregator.Core.Entities;

namespace JobAggregator.Core.Interfaces.Services;

public interface ILanguageService
{
    Task<Language?> GetAsync(int id);
    Task<IEnumerable<Language>> GetAllAsync();
    Task<Language> CreateAsync(Language language);
    Task<Language> UpdateAsync(Language language);
    Task<bool> DeleteAsync(int id);
    Task<Language?> GetByNameAsync(string name);
    Task<Language?> GetByCodeAsync(string code);
}
