using AutoMapper;
using ERP.MVC.Application.Models;
using ERP.MVC.Domain.Entities.Auth;
using ERP.MVC.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;


namespace ERP.MVC.Application.Commands.Branches
{
    public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, Result<string>>
    {
        private readonly IValidator<CreateBranchCommand> _validator;
        private readonly IBranchRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateBranchCommandHandler> _logger;
        public CreateBranchCommandHandler(IValidator<CreateBranchCommand> validator, IBranchRepository repository, IMapper mapper, ILogger<CreateBranchCommandHandler> logger)
        {
            _validator = validator;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<string>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return Result<string>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }
                
                var branch = _mapper.Map<Branch>(request);
                branch.CreatedBy = "CurrentUser Id";
                await _repository.AddAsync(branch);
                return Result<string>.Success(branch.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling CreateBranchCommand for BranchName: {BranchName}", request.BranchName);
                throw;
            }

        }

    }
}
