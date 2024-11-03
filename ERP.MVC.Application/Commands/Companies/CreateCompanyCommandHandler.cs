using ERP.MVC.Domain.Entities.MasterData;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Commands.Companies
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, string>
    {
        private readonly ICompanyRepository _repository;
        public CreateCompanyCommandHandler(ICompanyRepository repository)
        {
            _repository = repository;
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

            };

            await _repository.AddAsync(company);
            return company.Id;
        }
    }
}
