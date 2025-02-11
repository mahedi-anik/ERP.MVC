using ERP.MVC.Domain.Entities.MasterData;

namespace ERP.MVC.Domain.Interfaces
{
    public interface IProductBrandRepository : IGenericRepository<ProductBrand>
    {
        Task<bool> IsProductBrandExistAsync(string companyId, string branchId, string brandName);

    }
}
