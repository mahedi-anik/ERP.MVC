using ERP.MVC.Domain.Entities.Auth;
using ERP.MVC.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.MVC.Domain.Entities.MasterData
{
    public class AccountSubHeadType : AuditTrailBase
    {
        public string? CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public virtual Company? Company { get; set; }
        public string? BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public virtual Branch? Branch { get; set; }
        public string? AccountHeadTypeId { get; set; }
        [ForeignKey(nameof(AccountHeadTypeId))]
        public virtual AccountHeadType? AccountHeadType { get; set; }
        public string? AccountSubHeadTypeName { get; set; }
    }
}
