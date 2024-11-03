using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.Company
{
    public class GetCompaniesQuery : IRequest<List<CompanyDto>>
    {
    }
}
