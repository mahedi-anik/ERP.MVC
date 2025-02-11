using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.JournalVouchers
{
    public class GetJournalVoucherQueryHandler : IRequestHandler<GetJournalVoucherQuery, List<JournalVoucherDto>>
    {
        private readonly IJournaVoucherRepository _repository;
        private readonly IMapper _mapper;

        public GetJournalVoucherQueryHandler(IJournaVoucherRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<JournalVoucherDto>> Handle(GetJournalVoucherQuery request, CancellationToken cancellationToken)
        {
            var journalVoucher = await _repository.FindByConditionAsync(x => x.CompanyId == request.CompanyId &&
                                                                                x.BranchId == request.BranchId &&
                                                                                x.VoucherNo == request.VoucherNo,
                                                                                cancellationToken);

            return _mapper.Map<List<JournalVoucherDto>>(journalVoucher);
        }
    }
}
