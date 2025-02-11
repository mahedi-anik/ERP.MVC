using ERP.MVC.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.MVC.Domain.Entities.MasterData
{
    public class PurchaseOrder : AuditTrailBase
    {
        public string? ChallanNo { get; set; }
        public string? SupplierId { get; set; }
        [ForeignKey(nameof(SupplierId))]
        public virtual Supplier? Supplier { get; set; }
        public string? WarehouseId { get; set; }
        [ForeignKey(nameof(WarehouseId))]
        public virtual Warehouse? Warehouse { get; set; }
        public string? PurchaseType { get; set; }
        public string? LCNo { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public virtual ICollection<PurchaseOrderDetail>? PurchaseOrderDetails { get; set; }
    }
}
