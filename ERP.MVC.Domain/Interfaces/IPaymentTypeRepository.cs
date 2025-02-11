using ERP.MVC.Domain.Entities.MasterData;

namespace ERP.MVC.Domain.Interfaces
{
    public interface IPaymentTypeRepository : IGenericRepository<PaymentType>
    {
        Task<bool> IsPaymentTypeNameExistsAsync(string paymentTypeName);
    }
}
