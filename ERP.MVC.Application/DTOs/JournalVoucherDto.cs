using ERP.MVC.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace ERP.MVC.Application.DTOs
{
    public class JournalVoucherDto
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
        [Required(ErrorMessage = "Accounts sub head type is required.")]
        public string? AccountSubHeadTypeId { get; set; }
        public string? AccountSubHeadTypeName { get; set; }
        [Required(ErrorMessage = "Transaction head name is required.")]
        public string? TransactionHeadId { get; set; }
        public string? TransactionHeadName { get; set; }
        public DateTime Date { get; set; }
        public string? VoucherNo { get; set; }
        public decimal Cr { get; set; }
        public decimal Dr { get; set; }
        public string? PaymentTypeId { get; set; }
        public VoucherType VoucherType { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
