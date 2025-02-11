using ERP.MVC.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.MVC.Domain.Entities.MasterData
{
    public class PurchaseOrderDetail : AuditTrailBase
    {
        public string? PurchaseOrderId { get; set; }
        [ForeignKey(nameof(PurchaseOrderId))]
        public virtual PurchaseOrder? PurchaseOrder { get; set; }
        public string? ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product? Product { get; set; }
        public string? Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
