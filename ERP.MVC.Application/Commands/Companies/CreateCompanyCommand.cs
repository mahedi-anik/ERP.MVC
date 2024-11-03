using MediatR;

namespace ERP.MVC.Application.Commands.Companies
{
    public class CreateCompanyCommand : IRequest<string>
    {
        public string? CompanyName { get; set; }
        public string? MobileNo { get; set; }
        public string? OptionalMobileNo { get; set; }
        public string? TelephoneNo { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? ImageURL { get; set; }
        public bool IsActive { get; set; }
    }
}
