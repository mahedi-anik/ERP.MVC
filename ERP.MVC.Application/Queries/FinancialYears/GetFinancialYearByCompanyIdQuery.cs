using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.FinancialYears
{
    public class GetFinancialYearByCompanyIdQuery : IRequest<List<FinancialYearDto>>
    {
        public string CompanyId { get; set; }
    }
}
