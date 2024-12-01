using ERP.MVC.Domain.Entities.MasterData;

namespace ERP.MVC.Domain.Interfaces
{
    public interface IFinancialYearRepository : IGenericRepository<FinancialYear>
    {
        Task<bool> IsFinancialYearExistAsync(string companyId, string financialYearName, DateTime startDate, DateTime endDate);
    }
}
