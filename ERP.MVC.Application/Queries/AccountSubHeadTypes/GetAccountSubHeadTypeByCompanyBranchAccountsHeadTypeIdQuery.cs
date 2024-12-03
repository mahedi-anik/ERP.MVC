using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.AccountSubHeadTypes
{
    public class GetAccountSubHeadTypeByCompanyBranchAccountsHeadTypeIdQuery : IRequest<List<AccountsSubHeadTypeDto>>
    {
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string AccountHeadTypeId { get; set; }
    }
}
