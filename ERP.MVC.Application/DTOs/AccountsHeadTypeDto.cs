using System.ComponentModel.DataAnnotations;

namespace ERP.MVC.Application.DTOs
{
    public class AccountsHeadTypeDto
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "Company is required.")]
        public string? CompanyId { get; set; }
        public string? CompanyName { get; set; }
        [Required(ErrorMessage = "Accounts head type name is required.")]
        public string? AccountHeadTypeName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
