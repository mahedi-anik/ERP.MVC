using ERP.MVC.Domain.Entities.MasterData;

namespace ERP.MVC.Domain.Interfaces
{
    public interface IAccountHeadTypeRepository : IGenericRepository<AccountHeadType>
    {
        Task<bool> IsAccountHeadTypeNameExistsAsync(string companyId, string accountHeadTypeName);
    }
}
