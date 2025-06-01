namespace JobAggregator.Core.Interfaces.Repositories;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IRoleRepository RoleRepository { get; }
    IOrganizationRepository OrganizationRepository { get; }
    IVacancyRepository VacancyRepository { get; }
    Task<int> SaveAsync();
}
