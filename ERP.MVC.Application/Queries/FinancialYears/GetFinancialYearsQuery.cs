using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.FinancialYears
{
    public class GetFinancialYearsQuery : IRequest<List<FinancialYearDto>>
    {
    }
}
