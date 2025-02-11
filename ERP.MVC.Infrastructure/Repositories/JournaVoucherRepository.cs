using ERP.MVC.Domain.Entities.MasterData;
using ERP.MVC.Domain.Interfaces;
using ERP.MVC.Infrastructure.Persistence;

namespace ERP.MVC.Infrastructure.Repositories
{
    public class JournaVoucherRepository : GenericRepository<Transaction>, IJournaVoucherRepository
    {
        #region Fields
        private readonly ApplicationDbContext _context;

        #endregion

        #region Ctor
        public JournaVoucherRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        #endregion
    }
}
