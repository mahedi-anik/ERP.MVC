using ERP.MVC.Domain.Entities.Auth;
using ERP.MVC.Domain.Entities.MasterData;
using Microsoft.EntityFrameworkCore;

namespace ERP.MVC.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Auth Data
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserBranch> UserBranches { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Branch> Branches { get; set; }

        // Master Data
        public DbSet<Company> Companies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBranch>()
                .HasKey(ub => new { ub.UserId, ub.BranchId });

            // Additional configurations can be added here
        }
    }
}
