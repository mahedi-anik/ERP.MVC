using ERP.MVC.Domain.Entities.Base;

namespace ERP.MVC.Domain.Entities.MasterData
{
    public class ReturnProductQuality : AuditTrailBase
    {
        public string? ProductQuality { get; set; }
        public string? Remarks { get; set; }
    }
}
