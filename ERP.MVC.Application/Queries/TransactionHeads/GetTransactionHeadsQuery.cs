using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.TransactionHeads
{
    public class GetTransactionHeadsQuery : IRequest<List<TransactionHeadDto>>
    {
    }
}
