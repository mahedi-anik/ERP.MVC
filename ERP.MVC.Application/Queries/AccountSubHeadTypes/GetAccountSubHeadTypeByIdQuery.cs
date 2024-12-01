using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.AccountSubHeadTypes
{
    public class GetAccountSubHeadTypeByIdQuery : IRequest<AccountsSubHeadTypeDto>
    {
        public string Id { get; set; }
    }
}
