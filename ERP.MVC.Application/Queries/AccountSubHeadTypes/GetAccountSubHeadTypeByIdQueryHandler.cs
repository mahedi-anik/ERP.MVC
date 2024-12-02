using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.AccountSubHeadTypes
{
    public class GetAccountSubHeadTypeByIdQueryHandler : IRequestHandler<GetAccountSubHeadTypeByIdQuery, AccountsSubHeadTypeDto>
    {
        private readonly IAccountSubHeadTypeRepository _repository;
        private readonly IMapper _mapper;

        public GetAccountSubHeadTypeByIdQueryHandler(IAccountSubHeadTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<AccountsSubHeadTypeDto> Handle(GetAccountSubHeadTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var accountSubHeadType = await _repository.GetByIdAsync(request.Id, cancellationToken);
            return _mapper.Map<AccountsSubHeadTypeDto>(accountSubHeadType);
        }
    }
}
