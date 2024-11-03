using System.ComponentModel.DataAnnotations;

namespace ERP.MVC.Domain.Entities.Base
{
    public class AuditTrailBase : EntityBase
    {
        public AuditTrailBase()
        {
            CreatedDate = DateTime.Now;
            IsActive = true;
        }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }

}
