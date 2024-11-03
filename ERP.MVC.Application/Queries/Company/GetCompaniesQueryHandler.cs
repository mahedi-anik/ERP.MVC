using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.Company
{
    public class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesQuery, List<CompanyDto>>
    {
        private readonly ICompanyRepository _repository;
        private readonly IMapper _mapper;

        public GetCompaniesQueryHandler(ICompanyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<CompanyDto>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await _repository.GetAllAsync();
            return _mapper.Map<List<CompanyDto>>(companies);
        }
    }
}
