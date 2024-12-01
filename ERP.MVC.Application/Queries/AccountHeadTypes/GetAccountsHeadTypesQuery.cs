using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.AccountHeadTypes
{
    public class GetAccountsHeadTypesQuery : IRequest<List<AccountsHeadTypeDto>>
    {
    }
}
