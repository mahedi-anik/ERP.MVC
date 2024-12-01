using ERP.MVC.Domain.Entities.MasterData;
using ERP.MVC.Domain.Interfaces;
using ERP.MVC.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ERP.MVC.Infrastructure.Repositories
{
    public class AccountSubHeadTypeRepository : GenericRepository<AccountSubHeadType>, IAccountSubHeadTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public AccountSubHeadTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsAccountSubHeadTypeNameExistsAsync(string companyId, string branchId, string accountHeadTypeId, string accountSubHeadTypeName)
        {
            return await _context.AccountSubHeadTypes.AnyAsync(c => c.CompanyId == companyId &&
                                                       c.BranchId == branchId &&
                                                       c.AccountHeadTypeId == accountHeadTypeId &&
                                                       c.AccountSubHeadTypeName == accountSubHeadTypeName &&
                                                       c.IsDelete == true);
        }
    }
}
