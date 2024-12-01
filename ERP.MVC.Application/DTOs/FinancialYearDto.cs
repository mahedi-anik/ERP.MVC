using System.ComponentModel.DataAnnotations;

namespace ERP.MVC.Application.DTOs
{
    public class FinancialYearDto
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "Company is required.")]
        public string? CompanyId { get; set; }
        public string? CompanyName { get; set; }
        [Required(ErrorMessage = "Financial Year is required.")]
        public string? FinancialYearName { get; set; }
        [Required(ErrorMessage = "Financial year start date is required.")]
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "Financial year end date is required.")]
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
