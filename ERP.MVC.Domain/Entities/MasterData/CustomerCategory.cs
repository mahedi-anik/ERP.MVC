using ERP.MVC.Domain.Entities.Base;

namespace ERP.MVC.Domain.Entities.MasterData
{
    public class CustomerCategory : AuditTrailBase
    {
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Customer>? Customers { get; set; }
    }
}
