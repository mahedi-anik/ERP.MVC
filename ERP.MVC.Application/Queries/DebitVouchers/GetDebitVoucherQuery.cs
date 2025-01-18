using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.DebitVouchers
{
    public class GetDebitVoucherQuery : IRequest<List<DebitVoucherDto>>
    {
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string VoucherNo { get; set; }
    }
}
