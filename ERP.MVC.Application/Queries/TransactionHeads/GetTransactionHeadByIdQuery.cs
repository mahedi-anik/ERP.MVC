using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.TransactionHeads
{
    public class GetTransactionHeadByIdQuery : IRequest<TransactionHeadDto>
    {
        public string Id { get; set; }
    }
}
