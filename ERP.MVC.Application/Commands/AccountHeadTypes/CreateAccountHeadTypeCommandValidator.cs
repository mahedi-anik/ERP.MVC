using ERP.MVC.Domain.Interfaces;
using FluentValidation;

namespace ERP.MVC.Application.Commands.AccountHeadTypes
{
    public class CreateAccountHeadTypeCommandValidator : AbstractValidator<CreateAccountHeadTypeCommand>
    {
        private readonly IAccountHeadTypeRepository _repository;

        public CreateAccountHeadTypeCommandValidator(IAccountHeadTypeRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.CompanyId)
               .NotEmpty().WithMessage("CompanyId is required.");

            RuleFor(x => x.AccountHeadTypeName)
            .NotEmpty().WithMessage("Account Head Type Name is required.")
            .MustAsync(async (command, accountHeadTypeName, cancellation) =>
                !await _repository.IsAccountHeadTypeNameExistsAsync(command.CompanyId, accountHeadTypeName))
            .WithMessage("AccountHeadType Name already exists.");

        }
    }
}
