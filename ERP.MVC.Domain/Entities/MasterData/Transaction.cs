using ERP.MVC.Domain.Entities.Auth;
using ERP.MVC.Domain.Entities.Base;
using ERP.MVC.Domain.Entities.Enums;
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
        public string? AccountHeadTypeId { get; set; }
        [ForeignKey(nameof(AccountHeadTypeId))]
        public virtual AccountHeadType? AccountHeadType { get; set; }
        public string? AccountSubHeadTypeId { get; set; }
        [ForeignKey(nameof(AccountSubHeadTypeId))]
        public virtual AccountSubHeadType? AccountSubHeadType { get; set; }
        public string? TransactionHeadId { get; set; }
        [ForeignKey(nameof(TransactionHeadId))]
        public virtual TransactionHead? TransactionHead { get; set; }
        public DateTime Date { get; set; }
        public string? VoucherNo { get; set; }
        public decimal Cr { get; set; }
        public decimal Dr { get; set; }
        public string? PaymentTypeId { get; set; }
        public VoucherType VoucherType { get; set; }
        public string? Remarks { get; set; }

    }
}
