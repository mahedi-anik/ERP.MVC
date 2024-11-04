using AutoMapper;
using ERP.MVC.Application.Commands.Companies;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Entities.Auth;
using ERP.MVC.Domain.Entities.MasterData;

namespace ERP.MVC.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, RegisterUserRequest>();
            CreateMap<RegisterUserRequest, User>();
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();

            CreateMap<Company, CompanyDto>();
            CreateMap<CreateCompanyCommand, Company>();
        }
    }

}