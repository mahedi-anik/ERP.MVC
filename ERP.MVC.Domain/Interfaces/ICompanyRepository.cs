using ERP.MVC.Domain.Entities.MasterData;

namespace ERP.MVC.Domain.Interfaces
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<bool> IsCompanyNameExistsAsync(string companyName);
        Task<bool> IsEmailExistsAsync(string email);
        Task<bool> IsMobileNoExistsAsync(string mobileNo);
    }
}
