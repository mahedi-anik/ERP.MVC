using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.AccountSubHeadTypes
{
    public class GetAccountsSubHeadTypesQueryHandler : IRequestHandler<GetAccountsSubHeadTypesQuery, List<AccountsSubHeadTypeDto>>
    {
        private readonly IAccountSubHeadTypeRepository _repository;
        private readonly IMapper _mapper;

        public GetAccountsSubHeadTypesQueryHandler(IAccountSubHeadTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<AccountsSubHeadTypeDto>> Handle(GetAccountsSubHeadTypesQuery request, CancellationToken cancellationToken)
        {
            var accountSubHeadTypes = await _repository.GetAllAsync(
               cancellationToken, x => x.Company != null &&
                                  x.Branch != null &&
                                  x.AccountHeadType != null
           );
            return _mapper.Map<List<AccountsSubHeadTypeDto>>(accountSubHeadTypes);
        }
    }
}
