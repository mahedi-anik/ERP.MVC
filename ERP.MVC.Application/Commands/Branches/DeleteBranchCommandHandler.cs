using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Commands.Branches
{
    public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand>
    {
        private readonly IBranchRepository _repository;

        public DeleteBranchCommandHandler(IBranchRepository repository)
        {
            _repository = repository;
        }


        public async Task Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = await _repository.GetByIdAsync(request.Id);
            if (branch != null)
            {
                // Ensure this actually deletes the company from the repository, not just marking it as deleted.
                await _repository.IsDeleteAsync(branch.Id);  // or whatever method performs the actual delete
            }
        }
    }
}
