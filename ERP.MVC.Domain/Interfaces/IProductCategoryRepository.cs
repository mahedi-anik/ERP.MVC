using ERP.MVC.Domain.Entities.MasterData;

namespace ERP.MVC.Domain.Interfaces
{
    public interface IProductCategoryRepository: IGenericRepository<ProductCategory>
    {
        Task<bool> IsProductCategoryExistAsync(string companyId, string branchId, string categoryName);
    }
}
