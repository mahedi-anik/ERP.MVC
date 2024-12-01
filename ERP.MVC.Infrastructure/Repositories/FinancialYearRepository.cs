using ERP.MVC.Domain.Entities.MasterData;
using ERP.MVC.Domain.Interfaces;
using ERP.MVC.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ERP.MVC.Infrastructure.Repositories
{
    public class FinancialYearRepository : GenericRepository<FinancialYear>, IFinancialYearRepository
    {
        private readonly ApplicationDbContext _context;
        public FinancialYearRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsFinancialYearExistAsync(string companyId, string financialYearName, DateTime startDate, DateTime endDate)
        {
            return await _context.FinancialYears.AnyAsync(c => c.CompanyId == companyId &&
                                                        c.FinancialYearName == financialYearName &&
                                                        c.StartDate == startDate &&
                                                        c.EndDate == endDate &&
                                                        c.IsDelete == true);
        }
    }
}
