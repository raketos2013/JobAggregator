using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Infrastructure.Data;

namespace JobAggregator.Infrastructure.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork, IDisposable
{
    private IUserRepository? _userRepository;
    private IRoleRepository? _roleRepository;
    private IOrganizationRepository? _organizationRepository;
    private IVacancyRepository? _vacancyRepository;

    public IUserRepository UserRepository
    {
        get { return _userRepository ??= new UserRepository(context); }
    }

    public IRoleRepository RoleRepository
    {
        get { return _roleRepository ??= new RoleRepository(context); }
    }

    public IOrganizationRepository OrganizationRepository
    {
        get { return _organizationRepository ??= new OrganizationRepository(context); }
    }

    public IVacancyRepository VacancyRepository
    {
        get { return _vacancyRepository ??= new VacancyRepository(context); }
    }

    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }

    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
