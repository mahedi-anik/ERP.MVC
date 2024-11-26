using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.Branches
{
    public class GetBranchByIdQuery : IRequest<BranchDto>
    {
        public string Id { get; set; }
    }
}
