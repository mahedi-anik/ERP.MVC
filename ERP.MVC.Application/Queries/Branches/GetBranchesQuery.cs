using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.Branches
{
    public class GetBranchesQuery : IRequest<List<BranchDto>>
    {
    }
}
