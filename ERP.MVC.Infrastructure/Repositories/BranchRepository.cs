using ERP.MVC.Domain.Entities.Auth;
using ERP.MVC.Domain.Interfaces;
using ERP.MVC.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ERP.MVC.Infrastructure.Repositories
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        #region Fields
        private readonly ApplicationDbContext _context;

        #endregion

        #region Ctor
        public BranchRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<bool> IsBranchNameExistsAsync(string companyId, string branchName)
        {
            return await _context.Branches.AnyAsync(c => c.CompanyId == companyId &&
                                                         c.BranchName == branchName &&
                                                         c.IsDelete == true);

        }

        public async Task<bool> IsEmailExistsAsync(string email)
        {
            return await _context.Branches.AnyAsync(c => c.Email == email && c.IsDelete == true);
        }

        public async Task<bool> IsMobileNoExistsAsync(string mobileNo)
        {
            return await _context.Branches.AnyAsync(c => c.MobileNo == mobileNo && c.IsDelete == true);
        }

        #endregion
    }
}
