using Microsoft.AspNetCore.Mvc;

namespace ERP.MVC.Web.Models
{
    public class SearchPaginationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string searchQuery, int currentPage, int totalEntries, int pageSize, string sortField = "CompanyName", string sortOrder = "asc")
        {
            var model = new SearchPaginationModel
            {
                SearchQuery = searchQuery,
                CurrentPage = currentPage,
                TotalEntries = totalEntries,
                PageSize = pageSize,
                SortField = sortField,
                SortOrder = sortOrder
            };
            return View(model);
        }
    }
}
