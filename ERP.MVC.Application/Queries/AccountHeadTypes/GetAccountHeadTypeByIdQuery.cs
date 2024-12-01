using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.AccountHeadTypes
{
    public class GetAccountHeadTypeByIdQuery : IRequest<AccountsHeadTypeDto>
    {
        public string Id { get; set; }
    }
}
