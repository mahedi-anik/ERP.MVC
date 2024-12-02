using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.AccountHeadTypes
{
    public class GetAccountHeadTypeByCompanyIdQueryHandler : IRequestHandler<GetAccountHeadTypeByCompanyIdQuery, AccountsHeadTypeDto>
    {
        private readonly IAccountHeadTypeRepository _repository;
        private readonly IMapper _mapper;

        public GetAccountHeadTypeByCompanyIdQueryHandler(IAccountHeadTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Task<AccountsHeadTypeDto> Handle(GetAccountHeadTypeByCompanyIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
