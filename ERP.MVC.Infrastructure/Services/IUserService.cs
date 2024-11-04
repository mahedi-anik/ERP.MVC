using ERP.MVC.Domain.Entities.Auth;

namespace ERP.MVC.Infrastructure.Services
{
    public interface IUserService
    {
        User GetUserFromToken(string token);
        bool ValidateToken(string token);
        bool UserHasAccessToBranch(User user, string branchId);
        bool UserHasPermission(User user, string permissionName);
    }
}
