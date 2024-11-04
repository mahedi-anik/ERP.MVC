using ERP.MVC.Domain.Entities.Base;

namespace ERP.MVC.Domain.Entities.Auth
{
    public class Permission:AuditTrailBase
    {
        public string PermissionName { get; set; }
        public string Description { get; set; }
    }
}
