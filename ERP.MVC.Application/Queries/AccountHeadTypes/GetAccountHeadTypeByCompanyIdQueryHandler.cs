using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.AccountHeadTypes
{
    public class GetAccountHeadTypeByCompanyIdQueryHandler : IRequestHandler<GetAccountHeadTypeByCompanyIdQuery, List<AccountsHeadTypeDto>>
    {
        private readonly IAccountHeadTypeRepository _repository;
        private readonly IMapper _mapper;

        public GetAccountHeadTypeByCompanyIdQueryHandler(IAccountHeadTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AccountsHeadTypeDto>> Handle(GetAccountHeadTypeByCompanyIdQuery request, CancellationToken cancellationToken)
        {
            var accountHeadTypes = await _repository.FindByConditionAsync(x => x.CompanyId == request.CompanyId, cancellationToken);

            return _mapper.Map<List<AccountsHeadTypeDto>>(accountHeadTypes);
        }


    }
}
