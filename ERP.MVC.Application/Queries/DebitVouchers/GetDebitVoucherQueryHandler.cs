using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.DebitVouchers
{
    public class GetDebitVoucherQueryHandler : IRequestHandler<GetDebitVoucherQuery, List<DebitVoucherDto>>
    {
        private readonly IDebitVoucherRepository _repository;
        private readonly IMapper _mapper;

        public GetDebitVoucherQueryHandler(IDebitVoucherRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<DebitVoucherDto>> Handle(GetDebitVoucherQuery request, CancellationToken cancellationToken)
        {
            var debitVoucher = await _repository.FindByConditionAsync(x => x.CompanyId == request.CompanyId &&
                                                                                x.BranchId == request.BranchId &&
                                                                                x.VoucherNo == request.VoucherNo,
                                                                                cancellationToken);

            return _mapper.Map<List<DebitVoucherDto>>(debitVoucher);
        }
    }
}
