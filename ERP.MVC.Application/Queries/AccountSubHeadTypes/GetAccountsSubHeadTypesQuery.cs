using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.AccountSubHeadTypes
{
    public class GetAccountsSubHeadTypesQuery : IRequest<List<AccountsSubHeadTypeDto>>
    {
    }
}
