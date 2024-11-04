using ERP.MVC.Domain.Entities.Base;

namespace ERP.MVC.Domain.Entities.Auth
{
    public class User : AuditTrailBase
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public List<UserBranch> UserBranches { get; set; } = new();
        public List<Role> Roles { get; set; } = new();

        public bool HasPermission(string permissionName)
        {
            return Roles
                .SelectMany(r => r.RolePermissions)
                .Any(rp => rp.Permission.PermissionName.Equals(permissionName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
