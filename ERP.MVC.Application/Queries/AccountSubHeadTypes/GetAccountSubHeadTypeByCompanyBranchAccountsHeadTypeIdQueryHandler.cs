using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.AccountSubHeadTypes
{
    public class GetAccountSubHeadTypeByCompanyBranchAccountsHeadTypeIdQueryHandler : IRequestHandler<GetAccountSubHeadTypeByCompanyBranchAccountsHeadTypeIdQuery, List<AccountsSubHeadTypeDto>>
    {
        private readonly IAccountSubHeadTypeRepository _repository;
        private readonly IMapper _mapper;

        public GetAccountSubHeadTypeByCompanyBranchAccountsHeadTypeIdQueryHandler(IAccountSubHeadTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AccountsSubHeadTypeDto>> Handle(GetAccountSubHeadTypeByCompanyBranchAccountsHeadTypeIdQuery request, CancellationToken cancellationToken)
        {
            var accountHeadTypes = await _repository.FindByConditionAsync( x => x.CompanyId == request.CompanyId &&
                                                                                x.BranchId == request.BranchId &&
                                                                                x.AccountHeadTypeId == request.AccountHeadTypeId, cancellationToken);

            return _mapper.Map<List<AccountsSubHeadTypeDto>>(accountHeadTypes);
        }


    }
}
