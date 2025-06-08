using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Infrastructure.Data;

namespace JobAggregator.Infrastructure.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork, IDisposable
{
    private IUserRepository? _userRepository;
    private IRoleRepository? _roleRepository;
    private IOrganizationRepository? _organizationRepository;
    private IVacancyRepository? _vacancyRepository;
    private IResumeRepository? _resumeRepository;
    private IHandbookRepository<Requirement>? _handbookRepositoryRequirement;
    private IHandbookRepository<Responsibility>? _handbookRepositoryResponsibility;
    private IHandbookRepository<Offer>? _handbookRepositoryOffer;
    private IHandbookRepository<Specialisation>? _handbookRepositorySpecialisation;
    private IHandbookRepository<Skill>? _handbookRepositorySkill;
    private IHandbookRepository<Activity>? _handbookRepositoryActivity;
    private ILanguageRepository? _languageRepository;

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

    public IResumeRepository ResumeRepository
    {
        get { return _resumeRepository ??= new ResumeRepository(context); }
    }

    public IHandbookRepository<Requirement> HandbookRepositoryRequirement
    {
        get { return _handbookRepositoryRequirement ??= new HandBookRepository<Requirement>(context); }
    }

    public IHandbookRepository<Responsibility> HandbookRepositoryResponsibility
    {
        get { return _handbookRepositoryResponsibility ??= new HandBookRepository<Responsibility>(context); }
    }

    public IHandbookRepository<Offer> HandbookRepositoryOffer
    {
        get { return _handbookRepositoryOffer ??= new HandBookRepository<Offer>(context); }
    }

    public IHandbookRepository<Specialisation> HandbookRepositorySpecialisation
    {
        get { return _handbookRepositorySpecialisation ??= new HandBookRepository<Specialisation>(context); }
    }

    public IHandbookRepository<Skill> HandbookRepositorySkill
    {
        get { return _handbookRepositorySkill ??= new HandBookRepository<Skill>(context); }
    }

    public IHandbookRepository<Activity> HandbookRepositoryActivity
    {
        get { return _handbookRepositoryActivity ??= new HandBookRepository<Activity>(context); }
    }

    public ILanguageRepository LanguageRepository
    {
        get { return _languageRepository ??= new LanguageRepository(context); }
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
