using JobAggregator.Core.Entities;

namespace JobAggregator.Core.Interfaces.Repositories;

public interface ILanguageRepository : IRepositoryBase<Language>
{
    Task<Language?> GetByNameAsync(string name);
    Task<Language?> GetByCodeAsync(string code);
}
