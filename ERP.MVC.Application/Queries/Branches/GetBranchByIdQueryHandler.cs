using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.Branches
{
    public class GetBranchByIdQueryHandler : IRequestHandler<GetBranchByIdQuery, BranchDto>
    {
        private readonly IBranchRepository _repository;
        private readonly IMapper _mapper;

        public GetBranchByIdQueryHandler(IBranchRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BranchDto> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {
            var company = await _repository.GetByIdAsync(request.Id, cancellationToken);
            return _mapper.Map<BranchDto>(company);
        }
    }
}
