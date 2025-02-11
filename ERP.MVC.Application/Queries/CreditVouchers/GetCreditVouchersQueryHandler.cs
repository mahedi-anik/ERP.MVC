using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Entities.Enums;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.CreditVouchers
{
    public class GetCreditVouchersQueryHandler : IRequestHandler<GetCreditVouchersQuery, List<CreditVoucherDto>>
    {
        private readonly ICreditVoucherRepository _repository;
        private readonly IMapper _mapper;

        public GetCreditVouchersQueryHandler(ICreditVoucherRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<CreditVoucherDto>> Handle(GetCreditVouchersQuery request, CancellationToken cancellationToken)
        {
            var creditVouchers = await _repository.GetAllAsync(cancellationToken, x => x.Company,
                                                                                            x => x.Branch,
                                                                                            x => x.AccountHeadType,
                                                                                            x => x.AccountSubHeadType,
                                                                                            x => x.TransactionHead,
                                                                                            x => x.VoucherType == VoucherType.CR);



            var filteredCreditVouchers = creditVouchers
                .Where(x => x.Company != null && x.Branch != null && x.AccountHeadType != null && x.AccountSubHeadType != null && x.TransactionHead != null)
                .ToList();


            return _mapper.Map<List<CreditVoucherDto>>(filteredCreditVouchers);

        }
    }
}
