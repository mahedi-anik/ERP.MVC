using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.Branches
{
    public class GetBranchByCompanyIdQueryHandler : IRequestHandler<GetBranchByCompanyIdQuery, List<BranchDto>>
    {
        private readonly IBranchRepository _repository;
        private readonly IMapper _mapper;

        public GetBranchByCompanyIdQueryHandler(IBranchRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<BranchDto>> Handle(GetBranchByCompanyIdQuery request, CancellationToken cancellationToken)
        {
            var branches = await _repository.FindByConditionAsync(x => x.CompanyId == request.CompanyId, cancellationToken);

            return _mapper.Map<List<BranchDto>>(branches);
        }


    }
}
