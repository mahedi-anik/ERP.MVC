using ERP.MVC.Domain.Entities.Auth;

namespace ERP.MVC.Domain.Interfaces
{
    public interface IBranchRepository : IGenericRepository<Branch>
    {
        Task<bool> IsBranchNameExistsAsync(string companyId, string branchName);
        Task<bool> IsEmailExistsAsync(string email);
        Task<bool> IsMobileNoExistsAsync(string mobileNo);
    }
}
