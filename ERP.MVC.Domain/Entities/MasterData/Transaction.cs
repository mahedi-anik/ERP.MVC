using ERP.MVC.Domain.Entities.Auth;
using ERP.MVC.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.MVC.Domain.Entities.MasterData
{
    public class Transaction : AuditTrailBase
    {
        public string? CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public virtual Company? Company { get; set; }
        public string? BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public virtual Branch? Branch { get; set; }
        public string? TransactionHeadId { get; set; }
        [ForeignKey(nameof(TransactionHeadId))]
        public virtual TransactionHead? TransactionHead { get; set; }
        public DateTime Date { get; set; }
        public string? VoucherNo { get; set; }
        public string? VoucherType { get; set; }
        public decimal Cr { get; set; }
        public decimal Dr { get; set; }
        public string? PaymentTypeId { get; set; }
        [ForeignKey(nameof(PaymentTypeId))]
        public virtual PaymentType? PaymentType { get; set; }
        public string? Remarks { get; set; }

    }
}
