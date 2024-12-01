using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.FinancialYears
{
    public class GetFinancialYearsQueryHandler : IRequestHandler<GetFinancialYearsQuery, List<FinancialYearDto>>
    {
        private readonly IFinancialYearRepository _repository;
        private readonly IMapper _mapper;

        public GetFinancialYearsQueryHandler(IFinancialYearRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<FinancialYearDto>> Handle(GetFinancialYearsQuery request, CancellationToken cancellationToken)
        {
            var financialYears = await _repository.GetAllAsync(
                cancellationToken,
                x => x.Company != null 
            );
            return _mapper.Map<List<FinancialYearDto>>(financialYears);
        }
    }
}
