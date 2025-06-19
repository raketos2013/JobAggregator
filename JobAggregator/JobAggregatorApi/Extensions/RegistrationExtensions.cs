using FluentValidation;
using JobAggregator.Api.DTO;
using JobAggregator.Api.Validators;
using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Interfaces.Services;
using JobAggregator.Core.Services;
using JobAggregator.Infrastructure.Repositories;

namespace JobAggregator.Api.Extensions;

public static class RegistrationExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IOrganizationRepository, OrganizationRepository>();
        services.AddScoped<IResumeRepository, ResumeRepository>();
        services.AddScoped(typeof(IHandbookRepository<>), typeof(HandBookRepository<>));
        services.AddScoped<ILanguageRepository, LanguageRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IOrganizationService, OrganizationService>();
        services.AddScoped<IVacancyRepository, VacancyRepository>();
        services.AddScoped<IVacancyService, VacancyService>();
        services.AddScoped<IResumeService, ResumeService>();

        services.AddScoped<IRequirementService, RequirementService>();
        services.AddScoped<IResponsibilityService, ResponsibilityService>();
        services.AddScoped<IOfferService, OfferService>();
        services.AddScoped<ISpecialisationService, SpecialisationService>();
        services.AddScoped<ISkillService, SkillService>();
        services.AddScoped<ILanguageService, LanguageService>();
        services.AddScoped<IActivityService, ActivityService>();

        return services;
    }

    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<UserDTO>, UserDTOValidator>();
        services.AddScoped<IValidator<HandbookDTO>, HandbookDTOValidator<HandbookDTO>>();

        return services;
    }
}
