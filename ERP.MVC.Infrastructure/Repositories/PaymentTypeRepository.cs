using ERP.MVC.Domain.Entities.MasterData;
using ERP.MVC.Domain.Interfaces;
using ERP.MVC.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ERP.MVC.Infrastructure.Repositories
{
    public class PaymentTypeRepository : GenericRepository<PaymentType>, IPaymentTypeRepository
    {
        #region Fields
        private readonly ApplicationDbContext _context;

        #endregion

        #region Ctor
        public PaymentTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public async Task<bool> IsPaymentTypeNameExistsAsync(string paymentTypeName)
        {
            return await _context.PaymentTypes.AnyAsync(c => c.PaymentTypeName == paymentTypeName && c.IsDelete == true);

        }
        #endregion
    }
}
