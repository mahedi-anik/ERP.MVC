using ERP.MVC.Domain.Entities.Auth;

namespace ERP.MVC.Infrastructure.Services
{
    public class MenuService
    {
        public List<MenuItem> GetMenuForUser(User user)
        {
            var menuItems = new List<MenuItem>();

            if (user.HasPermission("ViewDashboard"))
            {
                menuItems.Add(new MenuItem { Name = "Dashboard", Url = "/dashboard" });
            }

            if (user.HasPermission("ManageUsers"))
            {
                menuItems.Add(new MenuItem { Name = "Users", Url = "/users" });
            }

            // Add more menu items based on permissions
            return menuItems;
        }
    }
}
