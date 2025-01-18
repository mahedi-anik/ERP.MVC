using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.CreditVouchers
{
    public class GetCreditVoucherQueryHandler : IRequestHandler<GetCreditVoucherQuery, List<CreditVoucherDto>>
    {
        private readonly ICreditVoucherRepository _repository;
        private readonly IMapper _mapper;

        public GetCreditVoucherQueryHandler(ICreditVoucherRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<CreditVoucherDto>> Handle(GetCreditVoucherQuery request, CancellationToken cancellationToken)
        {
            var creditVoucher = await _repository.FindByConditionAsync(x => x.CompanyId == request.CompanyId &&
                                                                                x.BranchId == request.BranchId &&
                                                                                x.VoucherNo == request.VoucherNo,
                                                                                cancellationToken);

            return _mapper.Map<List<CreditVoucherDto>>(creditVoucher);
        }
    }
}
