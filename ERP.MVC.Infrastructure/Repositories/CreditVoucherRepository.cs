using ERP.MVC.Domain.Entities.MasterData;
using ERP.MVC.Domain.Interfaces;
using ERP.MVC.Infrastructure.Persistence;

namespace ERP.MVC.Infrastructure.Repositories
{
    public class CreditVoucherRepository : GenericRepository<Transaction>, ICreditVoucherRepository
    {
        #region Fields
        private readonly ApplicationDbContext _context;

        #endregion

        #region Ctor
        public CreditVoucherRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        #endregion
    }
}
