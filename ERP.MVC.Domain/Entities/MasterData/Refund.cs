using ERP.MVC.Domain.Entities.Base;
using ERP.MVC.Domain.Entities.MasterData;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySales.MVC.Models.MasterData
{
    public class Refund : AuditTrailBase
    {
        public string? RefundNo { get; set; }
        public string? ReturnNo { get; set; }
        public string? ReturnOrderId { get; set; }
        [ForeignKey(nameof(ReturnOrderId))]
        public virtual ReturnOrder? ReturnOrder { get; set; }
        public string? CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer? Customer { get; set; }
        public decimal RefundAmount { get; set; }
        public string? PaymentTypeId { get; set; }
        [ForeignKey(nameof(PaymentTypeId))]
        public virtual TransactionHead? TransactionHead { get; set; }
        public DateTime RefundDate { get; set; }
        public string? Remarks { get; set; }
    }
}
