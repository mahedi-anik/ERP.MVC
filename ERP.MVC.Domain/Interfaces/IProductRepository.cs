using ERP.MVC.Domain.Entities.MasterData;

namespace ERP.MVC.Domain.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<bool> IsProductExistAsync(string companyId, string branchId, string brandId, string categoryId, string productName);

    }
}
