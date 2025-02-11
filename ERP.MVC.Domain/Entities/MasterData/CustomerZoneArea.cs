using ERP.MVC.Domain.Entities.Base;

namespace ERP.MVC.Domain.Entities.MasterData
{
    public class CustomerZoneArea : AuditTrailBase
    {
        public string? AreaName { get; set; }
        public string? Description { get; set; }
    }
}
