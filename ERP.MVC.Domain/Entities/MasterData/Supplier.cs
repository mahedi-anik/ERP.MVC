using ERP.MVC.Domain.Entities.Base;

namespace ERP.MVC.Domain.Entities.MasterData
{
    public class Supplier : AuditTrailBase
    {
        public string? SupplierName { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? ContactPersonName { get; set; }
        public string? ContactPersonMobile { get; set; }
        public string? Address { get; set; }
        public virtual ICollection<PurchaseOrder>? PurchaseOrders { get; set; }
    }
}
