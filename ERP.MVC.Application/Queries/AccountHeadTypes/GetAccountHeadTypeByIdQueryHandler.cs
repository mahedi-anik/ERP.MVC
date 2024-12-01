using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.AccountHeadTypes
{
    public class GetAccountHeadTypeByIdQueryHandler : IRequestHandler<GetAccountHeadTypeByIdQuery, AccountsHeadTypeDto>
    {
        private readonly IAccountHeadTypeRepository _repository;
        private readonly IMapper _mapper;

        public GetAccountHeadTypeByIdQueryHandler(IAccountHeadTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<AccountsHeadTypeDto> Handle(GetAccountHeadTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var accountHeadType = await _repository.GetByIdAsync(cancellationToken, request.Id);
            return _mapper.Map<AccountsHeadTypeDto>(accountHeadType);
        }
    }
}
