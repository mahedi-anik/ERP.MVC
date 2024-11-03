using ERP.MVC.Domain.Entities.MasterData;
using Microsoft.EntityFrameworkCore;

namespace ERP.MVC.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
    }
}
