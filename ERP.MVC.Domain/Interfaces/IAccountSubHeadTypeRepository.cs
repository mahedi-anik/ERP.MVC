using ERP.MVC.Domain.Entities.MasterData;

namespace ERP.MVC.Domain.Interfaces
{
    public interface IAccountSubHeadTypeRepository : IGenericRepository<AccountSubHeadType>
    {
        Task<bool> IsAccountSubHeadTypeNameExistsAsync(string companyId, string branchId, string accountHeadTypeId, string accountSubHeadTypeName);
    }
}
