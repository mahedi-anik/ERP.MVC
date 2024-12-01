using ERP.MVC.Application.Models;
using MediatR;

namespace ERP.MVC.Application.Commands.AccountHeadTypes
{
    public class CreateAccountHeadTypeCommand : IRequest<Result<string>>
    {
        public string? CompanyId { get; set; }
        public string? AccountHeadTypeName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
