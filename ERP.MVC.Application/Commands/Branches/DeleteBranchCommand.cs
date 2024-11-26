using MediatR;

namespace ERP.MVC.Application.Commands.Branches
{
    public class DeleteBranchCommand : IRequest
    {
        public string Id { get; set; }
    }
}
