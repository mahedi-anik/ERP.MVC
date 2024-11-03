using ERP.MVC.Domain.Entities.Base;

namespace ERP.MVC.Domain.Entities.MasterData
{
    public class Company : AuditTrailBase
    {
        public string? CompanyName { get; set; }
        public string? MobileNo { get; set; }
        public string? OptionalMobileNo { get; set; }
        public string? TelephoneNo { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? ImageURL { get; set; }
    }
}
