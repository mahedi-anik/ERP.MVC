using ERP.MVC.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.MVC.Domain.Entities.Auth
{
    public class UserBranch : AuditTrailBase
    {
        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; }
        public User User { get; set; }
        [ForeignKey(nameof(BranchId))]
        public string BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
