namespace ERP.MVC.Web.Models
{
    public class SearchPaginationModel
    {
        public string SearchQuery { get; set; }
        public int CurrentPage { get; set; }
        public int TotalEntries { get; set; }
        public int PageSize { get; set; }
        public string SortField { get; set; } 
        public string SortOrder { get; set; }

    }
}
