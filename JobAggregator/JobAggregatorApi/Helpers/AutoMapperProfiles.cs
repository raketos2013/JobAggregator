using AutoMapper;
using JobAggregator.Api.DTO;
using JobAggregator.Core.Entities;

namespace JobAggregator.Api.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<UserDTO, User>();
        CreateMap<User, UserDTO>();
        CreateMap<Role, RoleDTO>();
        CreateMap<RoleDTO, Role>();
        CreateMap<Organization, OrganizationDTO>();
        CreateMap<OrganizationDTO, Organization>();
        CreateMap<Vacancy, VacancyDTO>();
        CreateMap<VacancyDTO, Vacancy>();
        CreateMap<Resume, ResumeDTO>();
        CreateMap<ResumeDTO, Resume>();
        CreateMap<Responsibility, HandbookDTO>();
        CreateMap<HandbookDTO, Responsibility>();
        CreateMap<Requirement, HandbookDTO>();
        CreateMap<HandbookDTO, Requirement>();
        CreateMap<Offer, HandbookDTO>();
        CreateMap<HandbookDTO, Offer>();
        CreateMap<Specialisation, HandbookDTO>();
        CreateMap<HandbookDTO, Specialisation>();
        CreateMap<Skill, HandbookDTO>();
        CreateMap<HandbookDTO, Skill>();
        CreateMap<Activity, HandbookDTO>();
        CreateMap<HandbookDTO, Activity>();
        CreateMap<Language, LanguageDTO>();
        CreateMap<LanguageDTO, Language>();
    }
}
