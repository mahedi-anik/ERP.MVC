using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.FinancialYears
{
    public class GetFinancialYearByCompanyIdQueryHandler : IRequestHandler<GetFinancialYearByCompanyIdQuery, List<FinancialYearDto>>
    {
        private readonly IFinancialYearRepository _repository;
        private readonly IMapper _mapper;

        public GetFinancialYearByCompanyIdQueryHandler(IFinancialYearRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<FinancialYearDto>> Handle(GetFinancialYearByCompanyIdQuery request, CancellationToken cancellationToken)
        {
            var financialYear = await _repository.FindByConditionAsync(x => x.CompanyId == request.CompanyId, cancellationToken);
            return _mapper.Map<List<FinancialYearDto>>(financialYear);
        }
    }
}
