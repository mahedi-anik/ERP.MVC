using ERP.MVC.Domain.Entities.Auth;
using System.Security.Claims;

namespace ERP.MVC.Infrastructure.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        bool ValidateToken(string token);
        IEnumerable<Claim> GetClaimsFromToken(string token);
    }
}
