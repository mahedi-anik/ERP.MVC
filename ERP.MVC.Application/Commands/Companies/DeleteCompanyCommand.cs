using MediatR;

namespace ERP.MVC.Application.Commands.Companies
{
    public class DeleteCompanyCommand : IRequest
    {
        public string Id { get; set; }
    }
}
