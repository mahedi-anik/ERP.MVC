using MediatR;

namespace ERP.MVC.Application.Commands.AccountHeadTypes
{
    public class UpdateAccountHeadTypeCommand : IRequest<string>
    {
        public string? Id { get; set; }
        public string? CompanyId { get; set; }
        public string? AccountHeadTypeName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
