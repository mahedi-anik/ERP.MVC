using ERP.MVC.Domain.Entities.MasterData;

namespace ERP.MVC.Domain.Interfaces
{
    public interface ITransactionHeadRepository : IGenericRepository<TransactionHead>
    {
        Task<bool> IsTransactionHeadExistAsync(string companyId, string branchId, string accountHeadTypeId, string accountSubHeadTypeId, string transactionHeadName);
    }
}
