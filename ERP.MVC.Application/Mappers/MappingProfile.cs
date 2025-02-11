using AutoMapper;
using ERP.MVC.Application.Commands.AccountHeadTypes;
using ERP.MVC.Application.Commands.AccountSubHeadTypes;
using ERP.MVC.Application.Commands.Branches;
using ERP.MVC.Application.Commands.Companies;
using ERP.MVC.Application.Commands.FinancialYears;
using ERP.MVC.Application.Commands.PaymentTypes;
using ERP.MVC.Application.Commands.TransactionHeads;
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

            CreateMap<FinancialYear, FinancialYearDto>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.Id))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName));
            CreateMap<CreateFinancialYearCommand, FinancialYear>()
                .ForMember(dest => dest.IsDelete, opt => opt.MapFrom(src => true));
            CreateMap<UpdateFinancialYearCommand, FinancialYear>();

            CreateMap<AccountHeadType, AccountsHeadTypeDto>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.Id))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName));
            CreateMap<CreateAccountHeadTypeCommand, AccountHeadType>()
                .ForMember(dest => dest.IsDelete, opt => opt.MapFrom(src => true));
            CreateMap<UpdateAccountHeadTypeCommand, AccountHeadType>();

            CreateMap<AccountSubHeadType, AccountsSubHeadTypeDto>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.Id))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName))
                .ForMember(dest => dest.BranchId, opt => opt.MapFrom(src => src.Branch.Id))
                .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchName))
                .ForMember(dest => dest.AccountHeadTypeId, opt => opt.MapFrom(src => src.AccountHeadType.Id))
                .ForMember(dest => dest.AccountHeadTypeName, opt => opt.MapFrom(src => src.AccountHeadType.AccountHeadTypeName));
            CreateMap<CreateAccountSubHeadTypeCommand, AccountSubHeadType>()
                .ForMember(dest => dest.IsDelete, opt => opt.MapFrom(src => true));
            CreateMap<UpdateAccountSubHeadTypeCommand, AccountSubHeadType>();

            CreateMap<TransactionHead, TransactionHeadDto>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.Id))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName))
                .ForMember(dest => dest.BranchId, opt => opt.MapFrom(src => src.Branch.Id))
                .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchName))
                .ForMember(dest => dest.AccountHeadTypeId, opt => opt.MapFrom(src => src.AccountHeadType.Id))
                .ForMember(dest => dest.AccountHeadTypeName, opt => opt.MapFrom(src => src.AccountHeadType.AccountHeadTypeName))
                .ForMember(dest => dest.AccountSubHeadTypeId, opt => opt.MapFrom(src => src.AccountSubHeadType.Id))
                .ForMember(dest => dest.AccountSubHeadTypeName, opt => opt.MapFrom(src => src.AccountSubHeadType.AccountSubHeadTypeName));
            CreateMap<CreateTransactionHeadCommand, TransactionHead>()
                .ForMember(dest => dest.IsDelete, opt => opt.MapFrom(src => true));
            CreateMap<UpdateTransactionHeadCommand, TransactionHead>();

            CreateMap<PaymentType, PaymentTypeDto>();
            CreateMap<CreatePaymentTypeCommand, PaymentType>()
                .ForMember(dest => dest.IsDelete, opt => opt.MapFrom(src => true));
            CreateMap<UpdatePaymentTypeCommand, PaymentType>();
        }
    }

}