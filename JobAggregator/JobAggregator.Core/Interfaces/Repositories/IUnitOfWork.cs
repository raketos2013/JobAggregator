using JobAggregator.Core.Entities;

namespace JobAggregator.Core.Interfaces.Repositories;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IRoleRepository RoleRepository { get; }
    IOrganizationRepository OrganizationRepository { get; }
    IVacancyRepository VacancyRepository { get; }
    IResumeRepository ResumeRepository { get; }
    IHandbookRepository<Requirement> HandbookRepositoryRequirement { get; }
    IHandbookRepository<Responsibility> HandbookRepositoryResponsibility { get; }
    IHandbookRepository<Offer> HandbookRepositoryOffer { get; }
    IHandbookRepository<Specialisation> HandbookRepositorySpecialisation { get; }
    IHandbookRepository<Skill> HandbookRepositorySkill { get; }
    IHandbookRepository<Activity> HandbookRepositoryActivity { get; }
    ILanguageRepository LanguageRepository { get; }
    Task<int> SaveAsync();
}
