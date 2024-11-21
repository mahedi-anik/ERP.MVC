using ERP.MVC.Domain.Entities.MasterData;
using ERP.MVC.Domain.Interfaces;
using ERP.MVC.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ERP.MVC.Infrastructure.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsCompanyNameExistsAsync(string companyName)
        {
            return await _context.Companies.AnyAsync(c => c.CompanyName == companyName && c.IsDelete == true);
        }

        public async Task<bool> IsEmailExistsAsync(string email)
        {
            return await _context.Companies.AnyAsync(c => c.Email == email && c.IsDelete == true);
        }

        public async Task<bool> IsMobileNoExistsAsync(string mobileNo)
        {
            return await _context.Companies.AnyAsync(c => c.MobileNo == mobileNo && c.IsDelete == true);
        }
    }
}
