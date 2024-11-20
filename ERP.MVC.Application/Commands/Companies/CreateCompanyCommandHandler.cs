using ERP.MVC.Domain.Entities.MasterData;
using ERP.MVC.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ERP.MVC.Application.Commands.Companies
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, string>
    {
        private readonly ICompanyRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateCompanyCommandHandler(ICompanyRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new Company
            {
                CompanyName = request.CompanyName,
                MobileNo = request.MobileNo,
                OptionalMobileNo = request.OptionalMobileNo,
                TelephoneNo = request.TelephoneNo,
                Email  = request.Email,
                Address = request.Address,
                IsActive=request.IsActive,
                ImageURL = request.ImageURL,
                IsDelete=true,
                CreatedBy = _httpContextAccessor.HttpContext?.User.Identity?.Name ?? "Unknown"
            };

            await _repository.AddAsync(company);
            return company.Id;
        }
    }
}
