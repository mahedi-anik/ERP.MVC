using ERP.MVC.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.MVC.Domain.Entities.MasterData
{
    public class Product : AuditTrailBase
    {
        public string? ProductCategoryId { get; set; }
        [ForeignKey(nameof(ProductCategoryId))]
        public virtual ProductCategory? ProductCategory { get; set; }
        public string? ProductName { get; set; }
        public string? ProductBrandId { get; set; }
        [ForeignKey(nameof(ProductBrandId))]
        public virtual ProductBrand? ProductBrand { get; set; }
        public string? UnitMeasurementId { get; set; }
        [ForeignKey(nameof(UnitMeasurementId))]
        public virtual UnitOfMeasurement? UnitOfMeasurement { get; set; }
        public string? ShortName { get; set; }
        public string? Code { get; set; }
        public string? ImageURL { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<PurchaseOrderDetail>? PurchaseOrderDetails { get; set; }
        public virtual ICollection<SalesOrderDetail>? SalesOrderDetails { get; set; }
    }
}
