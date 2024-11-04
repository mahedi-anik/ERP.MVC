using ERP.MVC.Domain.Entities.Auth;
using ERP.MVC.Domain.Interfaces;
using System.Security.Claims;

namespace ERP.MVC.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService; // This is a hypothetical service for managing tokens.

        public UserService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public User GetUserFromToken(string token)
        {
            var claims = _tokenService.GetClaimsFromToken(token);
            var username = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            return _userRepository.GetByUsernameAsync(username).Result; // Ideally use async/await pattern
        }

        public bool ValidateToken(string token)
        {
            return _tokenService.ValidateToken(token);
        }

        public bool UserHasAccessToBranch(User user, string branchId)
        {
            return user.UserBranches.Any(ub => ub.BranchId == branchId);
        }

        public bool UserHasPermission(User user, string permissionName)
        {
            return user.Roles
                .SelectMany(r => r.RolePermissions)
                .Any(rp => rp.Permission.PermissionName.Equals(permissionName, StringComparison.OrdinalIgnoreCase));
        }

    }
}
