using System.ComponentModel.DataAnnotations;

namespace ERP.MVC.Application.DTOs
{
    public class AccountsSubHeadTypeDto
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "Company is required.")]
        public string? CompanyId { get; set; }
        public string? CompanyName { get; set; }
        [Required(ErrorMessage = "Branch is required.")]
        public string? BranchId { get; set; }
        public string? BranchName { get; set; }
        [Required(ErrorMessage = "Accounts head type is required.")]
        public string? AccountHeadTypeId { get; set; }
        public string? AccountHeadTypeName { get; set; }
        [Required(ErrorMessage = "Account subHead type name is required.")]
        public string? AccountSubHeadTypeName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
