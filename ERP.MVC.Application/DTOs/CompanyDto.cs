using System.ComponentModel.DataAnnotations;

namespace ERP.MVC.Application.DTOs
{
    public class CompanyDto
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "Company Name is required.")]
        public string? CompanyName { get; set; }
        [Required(ErrorMessage = "Mobile No is required.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Mobile No must contain only numbers.")]
        public string? MobileNo { get; set; }
        [RegularExpression(@"^\d+$", ErrorMessage = "Mobile No must contain only numbers.")]
        public string? OptionalMobileNo { get; set; }
        [RegularExpression(@"^\d+$", ErrorMessage = "Telephone No must contain only numbers.")]
        public string? TelephoneNo { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? ImageURL { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
