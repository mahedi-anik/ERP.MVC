using AutoMapper;
using ERP.MVC.Application.Models;
using ERP.MVC.Domain.Entities.MasterData;
using ERP.MVC.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ERP.MVC.Application.Commands.AccountSubHeadTypes
{
    public class CreateAccountSubHeadTypeCommandHandler : IRequestHandler<CreateAccountSubHeadTypeCommand, Result<string>>
    {
        private readonly IValidator<CreateAccountSubHeadTypeCommand> _validator;
        private readonly IAccountSubHeadTypeRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateAccountSubHeadTypeCommandHandler> _logger;
        public CreateAccountSubHeadTypeCommandHandler(
            IValidator<CreateAccountSubHeadTypeCommand> validator,
            IAccountSubHeadTypeRepository repository,
            IMapper mapper,
            ILogger<CreateAccountSubHeadTypeCommandHandler> logger)
        {
            _validator = validator;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Result<string>> Handle(CreateAccountSubHeadTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return Result<string>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                var accountSubHeadType = _mapper.Map<AccountSubHeadType>(request);
                accountSubHeadType.CreatedBy = "CurrentUser Id";
                await _repository.AddAsync(accountSubHeadType);
                return Result<string>.Success(accountSubHeadType.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling CreateFinancialYearCommand for AccountSubHeadTypeName: {AccountSubHeadTypeName}", request.AccountSubHeadTypeName);
                throw;
            }
        }
    }
}
