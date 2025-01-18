using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Entities.Enums;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.DebitVouchers
{
    public class GetDebitVouchersQueryHandler : IRequestHandler<GetDebitVouchersQuery, List<DebitVoucherDto>>
    {
        private readonly IDebitVoucherRepository _repository;
        private readonly IMapper _mapper;

        public GetDebitVouchersQueryHandler(IDebitVoucherRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<DebitVoucherDto>> Handle(GetDebitVouchersQuery request, CancellationToken cancellationToken)
        {
            var debitVouchers = await _repository.GetAllAsync(cancellationToken, x => x.Company,
                                                                                            x => x.Branch,
                                                                                            x => x.AccountHeadType,
                                                                                            x => x.AccountSubHeadType,
                                                                                            x => x.TransactionHead,
                                                                                            x => x.VoucherType == VoucherType.DR);



            var filteredDebitVouchers = debitVouchers
                .Where(x => x.Company != null && x.Branch != null && x.AccountHeadType != null && x.AccountSubHeadType != null && x.TransactionHead != null)
                .ToList();


            return _mapper.Map<List<DebitVoucherDto>>(filteredDebitVouchers);

        }
    }
}
