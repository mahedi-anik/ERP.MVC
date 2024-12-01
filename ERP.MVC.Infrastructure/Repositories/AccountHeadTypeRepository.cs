using ERP.MVC.Domain.Entities.MasterData;
using ERP.MVC.Domain.Interfaces;
using ERP.MVC.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ERP.MVC.Infrastructure.Repositories
{
    public class AccountHeadTypeRepository : GenericRepository<AccountHeadType>, IAccountHeadTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public AccountHeadTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsAccountHeadTypeNameExistsAsync(string companyId, string accountHeadTypeName)
        {
            return await _context.AccountHeadTypes.AnyAsync(c => c.CompanyId == companyId &&
                                                       c.AccountHeadTypeName == accountHeadTypeName &&
                                                       c.IsDelete == true);
        }
    }
}
