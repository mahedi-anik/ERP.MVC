using ERP.MVC.Domain.Entities.MasterData;
using ERP.MVC.Domain.Interfaces;
using ERP.MVC.Infrastructure.Persistence;

namespace ERP.MVC.Infrastructure.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
