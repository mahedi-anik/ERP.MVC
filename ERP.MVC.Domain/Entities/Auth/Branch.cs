using ERP.MVC.Domain.Entities.Base;

namespace ERP.MVC.Domain.Entities.Auth
{
    public class Branch : AuditTrailBase
    {
        public string BranchName { get; set; }
        public string? MobileNo { get; set; }
        public string? TelephoneNo { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; }
    }
}
