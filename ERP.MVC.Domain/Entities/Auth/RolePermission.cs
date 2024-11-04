using ERP.MVC.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.MVC.Domain.Entities.Auth
{
    public class RolePermission : AuditTrailBase
    {
        [ForeignKey(nameof(RoleId))]
        public string RoleId { get; set; }
        public Role Role { get; set; }
        [ForeignKey(nameof(PermissionId))]
        public string PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
