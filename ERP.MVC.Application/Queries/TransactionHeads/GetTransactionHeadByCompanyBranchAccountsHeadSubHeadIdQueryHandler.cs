using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.TransactionHeads
{
    public class GetTransactionHeadByCompanyBranchAccountsHeadSubHeadIdQueryHandler : IRequestHandler<GetTransactionHeadByCompanyBranchAccountsHeadSubHeadIdQuery, List<TransactionHeadDto>>
    {
        private readonly ITransactionHeadRepository _repository;
        private readonly IMapper _mapper;

        public GetTransactionHeadByCompanyBranchAccountsHeadSubHeadIdQueryHandler(ITransactionHeadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TransactionHeadDto>> Handle(GetTransactionHeadByCompanyBranchAccountsHeadSubHeadIdQuery request, CancellationToken cancellationToken)
        {
            var accountHeadTypes = await _repository.FindByConditionAsync(x => x.CompanyId == request.CompanyId &&
                                                                                x.BranchId == request.BranchId &&
                                                                                x.AccountHeadTypeId == request.AccountHeadTypeId &&
                                                                                x.AccountSubHeadTypeId == request.AccountSubHeadTypeId,
                                                                                cancellationToken);

            return _mapper.Map<List<TransactionHeadDto>>(accountHeadTypes);
        }


    }
}
