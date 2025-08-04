using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobAggregator.Infrastructure.Repositories;

public class ResumeRepository(AppDbContext context)
    : RepositoryBase<Resume>(context), IResumeRepository
{
    new public async Task<Resume?> GetAsync(int id)
    {
        return await context.Resumes
                            .Include(a => a.Languages)
                            .Include(d => d.Skills)
                            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Resume>> GetResumesByUserIdAsync(int id)
    {
        return await context.Resumes.Where(x => x.UserId == id).ToListAsync();
    }
}
