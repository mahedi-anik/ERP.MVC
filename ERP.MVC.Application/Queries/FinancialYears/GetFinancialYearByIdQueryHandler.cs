using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.FinancialYears
{
    public class GetFinancialYearByIdQueryHandler : IRequestHandler<GetFinancialYearByIdQuery, FinancialYearDto>
    {
        private readonly IFinancialYearRepository _repository;
        private readonly IMapper _mapper;

        public GetFinancialYearByIdQueryHandler(IFinancialYearRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<FinancialYearDto> Handle(GetFinancialYearByIdQuery request, CancellationToken cancellationToken)
        {
            var financialYear = await _repository.GetByIdAsync(cancellationToken, request.Id);
            return _mapper.Map<FinancialYearDto>(financialYear);
        }
    }
}
