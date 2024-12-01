using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.TransactionHeads
{
    public class GetTransactionHeadByIdQueryHandler : IRequestHandler<GetTransactionHeadByIdQuery, TransactionHeadDto>
    {
        private readonly ITransactionHeadRepository _repository;
        private readonly IMapper _mapper;

        public GetTransactionHeadByIdQueryHandler(ITransactionHeadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<TransactionHeadDto> Handle(GetTransactionHeadByIdQuery request, CancellationToken cancellationToken)
        {
            var transactionHead = await _repository.GetByIdAsync(cancellationToken, request.Id);
            return _mapper.Map<TransactionHeadDto>(transactionHead);
        }
    }
}
