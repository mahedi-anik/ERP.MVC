using ERP.MVC.Domain.Interfaces;
using FluentValidation;

namespace ERP.MVC.Application.Commands.AccountSubHeadTypes
{
    public class CreateAccountSubHeadTypeCommandValidator : AbstractValidator<CreateAccountSubHeadTypeCommand>
    {
        private readonly IAccountSubHeadTypeRepository _repository;

        public CreateAccountSubHeadTypeCommandValidator(IAccountSubHeadTypeRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.CompanyId)
               .NotEmpty().WithMessage("Company is required.");
            RuleFor(x => x.BranchId)
               .NotEmpty().WithMessage("Branch is required.");
            RuleFor(x => x.AccountHeadTypeId)
               .NotEmpty().WithMessage("AccountHeadType is required.");

            RuleFor(x => x.AccountSubHeadTypeName)
            .NotEmpty().WithMessage("Account Sub Head Type Name is required.")
            .MustAsync(async (command, accountSubHeadTypeName, cancellation) =>
                !await _repository.IsAccountSubHeadTypeNameExistsAsync(command.CompanyId, command.BranchId, command.AccountHeadTypeId, accountSubHeadTypeName))
            .WithMessage("AccountSubHeadType Name already exists.");

        }
    }

}
