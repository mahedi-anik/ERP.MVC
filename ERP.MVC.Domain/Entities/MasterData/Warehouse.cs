using ERP.MVC.Domain.Entities.Base;

namespace ERP.MVC.Domain.Entities.MasterData
{
    public class Warehouse : AuditTrailBase
    {
        public string? WarehouseName { get; set; }
        public string? Location { get; set; }
        public string? ManagerName { get; set; }
        public string? ContactNumber { get; set; }
        public virtual ICollection<PurchaseOrder>? PurchaseOrders { get; set; }
    }

}
