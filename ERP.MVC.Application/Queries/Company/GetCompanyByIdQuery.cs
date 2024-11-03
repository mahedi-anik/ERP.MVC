using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.Company
{
    public class GetCompanyByIdQuery : IRequest<CompanyDto>
    {
        public string Id { get; set; }
    }
}
