using ERP.MVC.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.MVC.Domain.Entities.MasterData
{
    public class FinancialYear : AuditTrailBase
    {
        public string CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public virtual Company? Company { get; set; }
        public string? FinancialYearName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
