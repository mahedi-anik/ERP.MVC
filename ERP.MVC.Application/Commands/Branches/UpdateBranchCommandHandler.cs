using AutoMapper;
using ERP.MVC.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ERP.MVC.Application.Commands.Branches
{
    public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, string>
    {
        private readonly IBranchRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateBranchCommand> _logger;

        public UpdateBranchCommandHandler(IBranchRepository repository, IMapper mapper, ILogger<UpdateBranchCommand> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var branch = await _repository.GetByIdAsync(request.Id);
                if (branch == null)
                {
                    throw new Exception($"branch with ID {request.Id} not found.");
                }
                _mapper.Map(request, branch);
                await _repository.UpdateAsync(branch);
                return branch.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling UpdateBranchCommand for branchName: {branchName}", request.BranchName);
                throw;
            }
        }
    }
}
