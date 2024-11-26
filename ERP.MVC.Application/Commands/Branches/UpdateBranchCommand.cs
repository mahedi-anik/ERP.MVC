using MediatR;

namespace ERP.MVC.Application.Commands.Branches
{
    public class UpdateBranchCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string? CompanyId { get; set; }
        public string? BranchName { get; set; }
        public string? MobileNo { get; set; }
        public string? TelephoneNo { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
