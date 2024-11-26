using ERP.MVC.Application.Models;
using MediatR;

namespace ERP.MVC.Application.Commands.Branches
{
    public class CreateBranchCommand : IRequest<Result<string>>
    {
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
