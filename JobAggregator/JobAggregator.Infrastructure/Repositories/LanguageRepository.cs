using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobAggregator.Infrastructure.Repositories;

public class LanguageRepository(AppDbContext context)
    : RepositoryBase<Language>(context), ILanguageRepository
{
    public async Task<Language?> GetByNameAsync(string name)
    {
        return await context.Languages.FirstOrDefaultAsync(x => x.Name == name);
    }
    public async Task<Language?> GetByCodeAsync(string code)
    {
        return await context.Languages.FirstOrDefaultAsync(x => x.Code == code);
    }
}
