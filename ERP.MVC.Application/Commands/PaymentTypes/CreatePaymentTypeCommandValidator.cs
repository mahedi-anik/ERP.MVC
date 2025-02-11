using ERP.MVC.Domain.Interfaces;
using FluentValidation;

namespace ERP.MVC.Application.Commands.PaymentTypes
{
    public class CreatePaymentTypeCommandValidator : AbstractValidator<CreatePaymentTypeCommand>
    {
        private readonly IPaymentTypeRepository _repository;

        public CreatePaymentTypeCommandValidator(IPaymentTypeRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.PaymentTypeName)
                .NotEmpty().WithMessage("Payment Type Name is required.")
                .MustAsync(async (paymentTypeName, cancellation) => !await _repository.IsPaymentTypeNameExistsAsync(paymentTypeName))
                .WithMessage("Payment Type Name already exists.");

        }
    }
}
