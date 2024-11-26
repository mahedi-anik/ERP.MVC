using MediatR;
using Microsoft.AspNetCore.Http;

namespace ERP.MVC.Application.Commands.Companies
{
    public class UpdateCompanyCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string CompanyName { get; set; }
        public string MobileNo { get; set; }
        public string? OptionalMobileNo { get; set; }
        public string? TelephoneNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string ImageURL { get; set; }
        public bool IsDelete { get; set; }
    }
}
