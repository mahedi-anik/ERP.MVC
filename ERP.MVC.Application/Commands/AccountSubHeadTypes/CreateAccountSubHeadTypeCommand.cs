using ERP.MVC.Application.Models;
using MediatR;

namespace ERP.MVC.Application.Commands.AccountSubHeadTypes
{
    public class CreateAccountSubHeadTypeCommand : IRequest<Result<string>>
    {
        public string? CompanyId { get; set; }
        public string? BranchId { get; set; }
        public string? AccountHeadTypeId { get; set; }
        public string? AccountSubHeadTypeName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
