using ERP.MVC.Domain.Entities.Base;

namespace ERP.MVC.Domain.Entities.MasterData
{
    public class UnitOfMeasurement : AuditTrailBase
    {
        public string? MeasurementName { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
