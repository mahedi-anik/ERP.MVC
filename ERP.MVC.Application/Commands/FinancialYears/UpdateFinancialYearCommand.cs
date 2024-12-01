using MediatR;

namespace ERP.MVC.Application.Commands.FinancialYears
{
    public class UpdateFinancialYearCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string FinancialYearName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
