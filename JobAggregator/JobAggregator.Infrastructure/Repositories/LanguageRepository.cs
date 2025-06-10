using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace JobAggregator.Infrastructure.Repositories;

public class LanguageRepository(AppDbContext context)
    : RepositoryBase<Language>(context), ILanguageRepository
{
    public async Task<Language?> GetByNameAsync(string name)
    {
        return await context.Languages.FirstOrDefaultAsync(x => x.Name.Equals(name.Trim(), StringComparison.InvariantCultureIgnoreCase));
    }
    public async Task<Language?> GetByCodeAsync(string code)
    {
        return await context.Languages.FirstOrDefaultAsync(x => x.Code.Equals(code.Trim(), StringComparison.InvariantCultureIgnoreCase));
    }
}
