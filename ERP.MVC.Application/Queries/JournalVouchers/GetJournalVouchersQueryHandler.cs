using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Entities.Enums;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.JournalVouchers
{
    public class GetJournalVouchersQueryHandler : IRequestHandler<GetJournalVouchersQuery, List<JournalVoucherDto>>
    {
        private readonly IJournaVoucherRepository _repository;
        private readonly IMapper _mapper;

        public GetJournalVouchersQueryHandler(IJournaVoucherRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<JournalVoucherDto>> Handle(GetJournalVouchersQuery request, CancellationToken cancellationToken)
        {
            var journalVouchers = await _repository.GetAllAsync(cancellationToken, x => x.Company,
                                                                                            x => x.Branch,
                                                                                            x => x.AccountHeadType,
                                                                                            x => x.AccountSubHeadType,
                                                                                            x => x.TransactionHead,
                                                                                            x => x.VoucherType == VoucherType.JV);



            var filteredJournalVouchers = journalVouchers
                .Where(x => x.Company != null && x.Branch != null && x.AccountHeadType != null && x.AccountSubHeadType != null && x.TransactionHead != null)
                .ToList();


            return _mapper.Map<List<JournalVoucherDto>>(filteredJournalVouchers);

        }
    }
}
