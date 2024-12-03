using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.AccountHeadTypes
{
    public class GetAccountHeadTypeByCompanyIdQuery : IRequest<List<AccountsHeadTypeDto>>
    {
        public string CompanyId { get; set; }
    }
}
