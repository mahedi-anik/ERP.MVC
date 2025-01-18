using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.DebitVouchers
{
    public class GetDebitVouchersQuery : IRequest<List<DebitVoucherDto>>
    {
    }
}
