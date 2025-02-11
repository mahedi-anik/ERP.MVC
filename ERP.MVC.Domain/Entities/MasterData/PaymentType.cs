using ERP.MVC.Domain.Entities.Base;

namespace ERP.MVC.Domain.Entities.MasterData
{
    public class PaymentType : AuditTrailBase
    {
        public string? PaymentTypeName { get; set; }
        public string? Remarks { get; set; }
    }
}
