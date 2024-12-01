using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.Branches
{
    public class GetBranchesQueryHandler : IRequestHandler<GetBranchesQuery, List<BranchDto>>
    {
        private readonly IBranchRepository _repository;
        private readonly IMapper _mapper;

        public GetBranchesQueryHandler(IBranchRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<BranchDto>> Handle(GetBranchesQuery request, CancellationToken cancellationToken)
        {
            var branches = await _repository.GetAllAsync(
               cancellationToken,
               x => x.Company != null
           );
            return _mapper.Map<List<BranchDto>>(branches);
        }
    }
}
