using AutoMapper;
using ERP.MVC.Application.Models;
using ERP.MVC.Domain.Entities.MasterData;
using ERP.MVC.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;


namespace ERP.MVC.Application.Commands.PaymentTypes
{
    public class CreatePaymentTypeCommandHandler : IRequestHandler<CreatePaymentTypeCommand, Result<string>>
    {
        private readonly IValidator<CreatePaymentTypeCommand> _validator;
        private readonly IPaymentTypeRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePaymentTypeCommandHandler> _logger;

        public CreatePaymentTypeCommandHandler(IValidator<CreatePaymentTypeCommand> validator, IPaymentTypeRepository repository, IMapper mapper, ILogger<CreatePaymentTypeCommandHandler> logger)
        {
            _validator = validator;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<string>> Handle(CreatePaymentTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return Result<string>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                var paymentType = _mapper.Map<PaymentType>(request);
                paymentType.CreatedBy = "CurrentUser Id";
                await _repository.AddAsync(paymentType);
                return Result<string>.Success(paymentType.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling CreatePaymentTypeCommand for PaymentTypeName: {PaymentTypeName}", request.PaymentTypeName);
                throw;
            }

        }

    }
}
