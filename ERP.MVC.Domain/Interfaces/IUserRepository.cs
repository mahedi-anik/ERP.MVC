using ERP.MVC.Domain.Entities.Auth;

namespace ERP.MVC.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetByIdAsync(string userId);
        Task<User> GetByUsernameAsync(string username);
        Task<List<User>> GetAllAsync();
    }
}
