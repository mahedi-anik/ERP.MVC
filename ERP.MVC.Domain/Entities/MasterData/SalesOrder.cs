using ERP.MVC.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.MVC.Domain.Entities.MasterData
{
    public class SalesOrder : AuditTrailBase
    {
        public string? InvoiceNo { get; set; }
        public string? CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer? Customer { get; set; }
        public string? SalesmanId { get; set; }
        [ForeignKey(nameof(SalesmanId))]
        public virtual Salesman? Salesman { get; set; }
        public string? PaymentTypeId { get; set; }
        [ForeignKey(nameof(PaymentTypeId))]
        public virtual TransactionHead? TransactionHead { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public virtual ICollection<SalesOrderDetail>? SalesOrderDetails { get; set; }  
    }
}
