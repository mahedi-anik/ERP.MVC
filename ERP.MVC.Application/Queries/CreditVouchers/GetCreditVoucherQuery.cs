using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.CreditVouchers
{
    public class GetCreditVoucherQuery : IRequest<List<CreditVoucherDto>>
    {
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string VoucherNo { get; set; }
    }
}
