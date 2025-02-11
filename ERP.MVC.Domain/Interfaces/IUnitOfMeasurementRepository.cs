using ERP.MVC.Domain.Entities.MasterData;

namespace ERP.MVC.Domain.Interfaces
{
    public interface IUnitOfMeasurementRepository :IGenericRepository<UnitOfMeasurement>
    {
        Task<bool> IsUnitOfMeasurementExistAsync(string companyId, string branchId, string measurementName);

    }
}
