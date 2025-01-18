using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.JournalVouchers
{
    public class GetJournalVouchersQuery : IRequest<List<JournalVoucherDto>>
    {
    }
}
