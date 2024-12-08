using System.ComponentModel.DataAnnotations;

namespace ERP.MVC.Application.DTOs
{
    public class PaymentTypeDto
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "Payment Type Name is required.")]
        public string? PaymentTypeName { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
