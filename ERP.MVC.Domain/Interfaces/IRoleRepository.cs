using ERP.MVC.Domain.Entities.Auth;

namespace ERP.MVC.Domain.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllWithPermissionsAsync();
        Task<Role> GetByIdAsync(string roleId);
        Task AddAsync(Role role);
    }
}
