using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.Branches
{
    public class GetBranchByCompanyIdQuery : IRequest<List<BranchDto>>
    {
        public string CompanyId { get; set; }
    }
}
