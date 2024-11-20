using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Commands.Companies
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, string>
    {
        private readonly ICompanyRepository _repository;

        public UpdateCompanyCommandHandler(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _repository.GetByIdAsync(request.Id);
            if (company == null)
            {
                throw new Exception($"Company with ID {request.Id} not found.");
            }

            company.CompanyName = request.CompanyName;
            company.MobileNo = request.MobileNo;
            company.Email = request.Email;
            company.Address = request.Address;
            company.IsActive = request.IsActive;
            company.ImageURL = request.ImageURL;
            company.IsDelete = true;

            await _repository.UpdateAsync(company);
            return company.Id;
        }
    }
}
