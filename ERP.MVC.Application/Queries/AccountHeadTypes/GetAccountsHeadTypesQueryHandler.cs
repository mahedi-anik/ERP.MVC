using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.AccountHeadTypes
{
    public class GetAccountsHeadTypesQueryHandler : IRequestHandler<GetAccountsHeadTypesQuery, List<AccountsHeadTypeDto>>
    {
        private readonly IAccountHeadTypeRepository _repository;
        private readonly IMapper _mapper;

        public GetAccountsHeadTypesQueryHandler(IAccountHeadTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<AccountsHeadTypeDto>> Handle(GetAccountsHeadTypesQuery request, CancellationToken cancellationToken)
        {
            var accountHeadTypes = await _repository.GetAllAsync(
               cancellationToken,
               x => x.Company != null
           );
            return _mapper.Map<List<AccountsHeadTypeDto>>(accountHeadTypes);
        }
    }
}
