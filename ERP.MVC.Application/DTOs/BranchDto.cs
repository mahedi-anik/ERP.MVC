using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ERP.MVC.Application.DTOs
{
    public class BranchDto
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "Company is required.")]
        public string? CompanyId { get; set; }
        public string? CompanyName { get; set; }
        [Required(ErrorMessage = "Branch Name is required.")]
        public string? BranchName { get; set; }
        [Required(ErrorMessage = "Mobile No is required.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Mobile No must contain only numbers.")]
        public string? MobileNo { get; set; }
        [RegularExpression(@"^\d+$", ErrorMessage = "TelephoneNo must contain only numbers.")]
        public string? TelephoneNo { get; set; }
        public string? Email { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string? Address { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
