using ERP.MVC.Domain.Entities.Base;
using InventorySales.MVC.Models.MasterData;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.MVC.Domain.Entities.MasterData
{
    public class ReturnOrderDetail : AuditTrailBase
    {
        public string? ReturnOrderId { get; set; }
        [ForeignKey(nameof(ReturnOrderId))]
        public virtual ReturnOrder? ReturnOrder { get; set; }
        public string? ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product? Product { get; set; }
        public string? ProductQualityId { get; set; }
        [ForeignKey(nameof(ProductQualityId))]
        public virtual ReturnProductQuality? ReturnProductQuality { get; set; }
        public string? ReturnQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal RefundAmount { get; set; }
    }
}
