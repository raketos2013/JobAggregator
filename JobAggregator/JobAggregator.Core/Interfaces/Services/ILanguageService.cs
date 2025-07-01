using JobAggregator.Core.Entities;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Queries;

namespace JobAggregator.Core.Interfaces.Services;

public interface ILanguageService
{
    Task<Language?> GetAsync(int id);
    Task<PagedList<Language>> GetAllAsync(Query query);
    Task<Language> CreateAsync(Language language);
    Task<Language> UpdateAsync(Language language);
    Task<bool> DeleteAsync(int id);
    Task<Language?> GetByNameAsync(string name);
    Task<Language?> GetByCodeAsync(string code);
}
