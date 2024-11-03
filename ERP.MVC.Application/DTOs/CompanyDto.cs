using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.MVC.Application.DTOs
{
    public class CompanyDto
    {
        public string? Id { get; set; }
        public string? CompanyName { get; set; }
        public string? MobileNo { get; set; }
        public string? OptionalMobileNo { get; set; }
        public string? TelephoneNo { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? ImageURL { get; set; }
        public bool? IsActive { get; set; }
    }
}
