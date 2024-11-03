using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.Company
{
    public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, CompanyDto>
    {
        private readonly ICompanyRepository _repository;
        private readonly IMapper _mapper;

        public GetCompanyByIdQueryHandler(ICompanyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CompanyDto> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var company = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<CompanyDto>(company);
        }
    }
}
