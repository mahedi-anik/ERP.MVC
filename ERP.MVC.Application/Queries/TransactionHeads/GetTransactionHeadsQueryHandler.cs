using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.TransactionHeads
{
    public class GetTransactionHeadsQueryHandler : IRequestHandler<GetTransactionHeadsQuery, List<TransactionHeadDto>>
    {
        private readonly ITransactionHeadRepository _repository;
        private readonly IMapper _mapper;

        public GetTransactionHeadsQueryHandler(ITransactionHeadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<TransactionHeadDto>> Handle(GetTransactionHeadsQuery request, CancellationToken cancellationToken)
        {
            var transactionHeads = await _repository.GetAllAsync(cancellationToken, x => x.Company,
                                                                                            x => x.Branch,
                                                                                            x => x.AccountHeadType,
                                                                                            x => x.AccountSubHeadType);



            var filteredTransactionHeads = transactionHeads
                .Where(x => x.Company != null && x.Branch != null && x.AccountHeadType != null && x.AccountSubHeadType != null)
                .ToList();


            return _mapper.Map<List<TransactionHeadDto>>(filteredTransactionHeads);
        }
    }
}
