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
            var company = await _repository.GetByIdAsync(request.Id);
            if (company != null)
            {
                await _repository.DeleteAsync(company.Id);
            }
            return;
        }
    }
}
