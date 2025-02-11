using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.CreditVouchers
{
    public class GetCreditVouchersQuery : IRequest<List<CreditVoucherDto>>
    {
    }
}
