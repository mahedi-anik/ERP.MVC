using ERP.MVC.Domain.Entities.Base;
using ERP.MVC.Domain.Entities.MasterData;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.MVC.Domain.Entities.Auth
{
    public class Branch : AuditTrailBase
    {
        [ForeignKey(nameof(CompanyId))]
        public string CompanyId {  get; set; }
        public virtual Company Company { get; set; }
        public string? BranchName { get; set; }
        public string? MobileNo { get; set; }
        public string? TelephoneNo { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
