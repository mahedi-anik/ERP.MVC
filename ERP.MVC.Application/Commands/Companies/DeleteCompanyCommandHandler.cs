using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Commands.Companies
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
    {
        private readonly ICompanyRepository _repository;

        public DeleteCompanyCommandHandler(ICompanyRepository repository)
        {
            _repository = repository;
        }


        public async Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _repository.GetByIdAsync(cancellationToken, request.Id);
            if (company != null)
            {
                // Ensure this actually deletes the company from the repository, not just marking it as deleted.
                await _repository.IsDeleteAsync(cancellationToken, company.Id);  // or whatever method performs the actual delete
            }
        }
    }
}
