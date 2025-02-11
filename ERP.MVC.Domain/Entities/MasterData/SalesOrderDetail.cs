using ERP.MVC.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.MVC.Domain.Entities.MasterData
{
    public class SalesOrderDetail : AuditTrailBase
    {
        public string? SalesOrderId { get; set; }
        [ForeignKey(nameof(SalesOrderId))]
        public virtual SalesOrder? SalesOrder { get; set; }
        public string? ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product? Product { get; set; }
        public string? Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
