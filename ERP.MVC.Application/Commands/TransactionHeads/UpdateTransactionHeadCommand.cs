using MediatR;

namespace ERP.MVC.Application.Commands.TransactionHeads
{
    public class UpdateTransactionHeadCommand : IRequest<string>
    {
        public string? Id { get; set; }
        public string? CompanyId { get; set; }
        public string? BranchId { get; set; }
        public string? AccountHeadTypeId { get; set; }
        public string? AccountSubHeadTypeId { get; set; }
        public string? TransactionHeadName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
