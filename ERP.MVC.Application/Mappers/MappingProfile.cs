using AutoMapper;
using ERP.MVC.Application.Commands.Branches;
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
            CreateMap<CreateCompanyCommand, Company>()
                .ForMember(dest => dest.IsDelete, opt => opt.MapFrom(src => true));
            CreateMap<UpdateCompanyCommand, Company>();

            CreateMap<Branch, BranchDto>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.Id)) 
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName)); 
            CreateMap<CreateBranchCommand, Branch>()
                .ForMember(dest => dest.IsDelete, opt => opt.MapFrom(src => true));
            CreateMap<UpdateBranchCommand, Branch>();
        }
    }

}