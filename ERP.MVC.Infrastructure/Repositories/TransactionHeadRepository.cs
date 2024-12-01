using ERP.MVC.Domain.Entities.MasterData;
using ERP.MVC.Domain.Interfaces;
using ERP.MVC.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ERP.MVC.Infrastructure.Repositories
{
    public class TransactionHeadRepository : GenericRepository<TransactionHead>, ITransactionHeadRepository
    {
        private readonly ApplicationDbContext _context;
        public TransactionHeadRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsTransactionHeadExistAsync(string companyId, string branchId, string accountHeadTypeId, string accountSubHeadTypeId, string transactionHeadName)
        {
            return await _context.TransactionHeads.AnyAsync(c => c.CompanyId == companyId &&
                                                       c.BranchId == branchId &&
                                                       c.AccountHeadTypeId == accountHeadTypeId &&
                                                       c.AccountSubHeadTypeId == accountSubHeadTypeId &&
                                                       c.TransactionHeadName == transactionHeadName &&
                                                       c.IsDelete == true);
        }
    }
}
