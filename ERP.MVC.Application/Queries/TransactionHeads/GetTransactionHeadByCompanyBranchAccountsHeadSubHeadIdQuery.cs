using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.TransactionHeads
{
    public class GetTransactionHeadByCompanyBranchAccountsHeadSubHeadIdQuery : IRequest<List<TransactionHeadDto>>
    {
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string AccountHeadTypeId { get; set; }
        public string AccountSubHeadTypeId { get; set; }
    }
}
