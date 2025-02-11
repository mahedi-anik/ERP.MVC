using ERP.MVC.Domain.Entities.Base;
using ERP.MVC.Domain.Entities.MasterData;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySales.MVC.Models.MasterData
{
    public class ReturnOrder : AuditTrailBase
    {
        public string? ReturnNo { get; set; }
        public string? SalesOrderId { get; set; }
        public string? CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer? Customer { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal TotalRefundAmount { get; set; }
        public string? PaymentTypeId { get; set; }
        [ForeignKey(nameof(PaymentTypeId))]
        public virtual TransactionHead? TransactionHead { get; set; }
        public string? Remarks { get; set; }
        public virtual ICollection<ReturnOrderDetail>? ReturnOrderDetails { get; set; }
    }
}
