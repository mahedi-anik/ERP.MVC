using ERP.MVC.Domain.Entities.Base;

namespace ERP.MVC.Domain.Entities.Auth
{
    public class Role : AuditTrailBase
    {
        public string RoleName { get; set; }
        public List<RolePermission> RolePermissions { get; set; } = new();
    }
}
