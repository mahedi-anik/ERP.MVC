using ERP.MVC.Domain.Interfaces;
using FluentValidation;

namespace ERP.MVC.Application.Commands.Branches
{
    public class CreateBranchCommandValidator : AbstractValidator<CreateBranchCommand>
    {
        private readonly IBranchRepository _repository;

        public CreateBranchCommandValidator(IBranchRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.BranchName)
            .NotEmpty().WithMessage("Branch Name is required.")
            .MustAsync(async (command, branchName, cancellation) =>
                !await _repository.IsBranchNameExistsAsync(command.CompanyId, branchName))
            .WithMessage("Branch Name already exists.");

            RuleFor(x => x.MobileNo)
                .NotEmpty().WithMessage("Mobile No is required.")
                .MustAsync(async (mobileNo, cancellation) => !await _repository.IsMobileNoExistsAsync(mobileNo))
                .WithMessage("Mobile No already exists.");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Invalid email format.")
                .MustAsync(async (email, cancellation) => !await _repository.IsEmailExistsAsync(email))
                .WithMessage("Email already exists.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.");
        }
    }
}
