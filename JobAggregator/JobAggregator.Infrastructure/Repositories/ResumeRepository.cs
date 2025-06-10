using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Infrastructure.Data;

namespace JobAggregator.Infrastructure.Repositories;

public class ResumeRepository(AppDbContext context)
    : RepositoryBase<Resume>(context), IResumeRepository
{
}
