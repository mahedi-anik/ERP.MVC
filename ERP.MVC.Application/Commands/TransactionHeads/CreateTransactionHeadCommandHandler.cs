using AutoMapper;
using ERP.MVC.Application.Models;
using ERP.MVC.Domain.Entities.MasterData;
using ERP.MVC.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ERP.MVC.Application.Commands.TransactionHeads
{
    public class CreateTransactionHeadCommandHandler : IRequestHandler<CreateTransactionHeadCommand, Result<string>>
    {
        private readonly IValidator<CreateTransactionHeadCommand> _validator;
        private readonly ITransactionHeadRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateTransactionHeadCommandHandler> _logger;
        public CreateTransactionHeadCommandHandler(
            IValidator<CreateTransactionHeadCommand> validator,
            ITransactionHeadRepository repository,
            IMapper mapper,
            ILogger<CreateTransactionHeadCommandHandler> logger)
        {
            _validator = validator;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Result<string>> Handle(CreateTransactionHeadCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return Result<string>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                var transactionHead = _mapper.Map<TransactionHead>(request);
                transactionHead.CreatedBy = "CurrentUser Id";
                await _repository.AddAsync(transactionHead);
                return Result<string>.Success(transactionHead.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling CreateTransactionHeadCommand for TransactionHeadName: {TransactionHeadName}", request.TransactionHeadName);
                throw;
            }
        }
    }
}
