using ERP.MVC.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.MVC.Domain.Entities.MasterData
{
    public class Customer : AuditTrailBase
    {
        public string? CustomerCategoryId { get; set; }
        [ForeignKey(nameof(CustomerCategoryId))]
        public virtual CustomerCategory? CustomerCategory { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerZoneAreaId { get; set; }
        [ForeignKey(nameof(CustomerZoneAreaId))]
        public virtual CustomerZoneArea? CustomerZoneArea { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public virtual ICollection<SalesOrder>? SalesOrders { get; set; }
    }
}
