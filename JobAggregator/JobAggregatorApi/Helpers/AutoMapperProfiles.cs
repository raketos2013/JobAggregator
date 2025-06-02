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
    }
}
