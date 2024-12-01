using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.FinancialYears
{
    public class GetFinancialYearByIdQuery : IRequest<FinancialYearDto>
    {
        public string Id { get; set; }
    }
}
