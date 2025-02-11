using ERP.MVC.Domain.Entities.Base;

namespace ERP.MVC.Domain.Entities.MasterData
{
    public class Salesman : AuditTrailBase
    {
        public string? SalesmanName { get; set; }
        public string? Mobile { get; set; }
        public string? EmergencyContactPersonName { get; set; }
        public string? EmergencyContactPersonMobile { get; set; }
        public string? Address { get; set; }
        public string? ImageURL { get; set; }
        public virtual ICollection<SalesOrder>? SalesOrders { get; set; }
    }
}
