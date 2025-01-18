using ERP.MVC.Application.DTOs;
using MediatR;
using System.Collections.Generic;

namespace ERP.MVC.Application.Queries.JournalVouchers
{
    public class GetJournalVoucherQuery : IRequest<List<JournalVoucherDto>>
    {
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string VoucherNo { get; set; }
    }
}
