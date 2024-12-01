using AutoMapper;
using ERP.MVC.Application.Models;
using ERP.MVC.Domain.Entities.MasterData;
using ERP.MVC.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ERP.MVC.Application.Commands.AccountHeadTypes
{
    public class CreateAccountHeadTypeCommandHandler : IRequestHandler<CreateAccountHeadTypeCommand, Result<string>>
    {
        private readonly IValidator<CreateAccountHeadTypeCommand> _validator;
        private readonly IAccountHeadTypeRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateAccountHeadTypeCommandHandler> _logger;
        public CreateAccountHeadTypeCommandHandler(
            IValidator<CreateAccountHeadTypeCommand> validator,
            IAccountHeadTypeRepository repository,
            IMapper mapper,
            ILogger<CreateAccountHeadTypeCommandHandler> logger)
        {
            _validator = validator;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Result<string>> Handle(CreateAccountHeadTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return Result<string>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                var accountHeadType = _mapper.Map<AccountHeadType>(request);
                accountHeadType.CreatedBy = "CurrentUser Id";
                await _repository.AddAsync(accountHeadType);
                return Result<string>.Success(accountHeadType.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling CreateFinancialYearCommand for AccountHeadTypeName: {AccountHeadTypeName}", request.AccountHeadTypeName);
                throw;
            }
        }
    }
}
