using ERP.MVC.Domain.Interfaces;
using FluentValidation;

namespace ERP.MVC.Application.Commands.Companies
{
    public class CreateCompanyCommandValidator: AbstractValidator<CreateCompanyCommand>
    {
        private readonly ICompanyRepository _repository;

        public CreateCompanyCommandValidator(ICompanyRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Company Name is required.")
                .MustAsync(async (companyName, cancellation) => !await _repository.IsCompanyNameExistsAsync(companyName))
                .WithMessage("Company Name already exists.");

            RuleFor(x => x.MobileNo)
                .NotEmpty().WithMessage("Mobile No is required.")
                .MustAsync(async (mobileNo, cancellation) => !await _repository.IsMobileNoExistsAsync(mobileNo))
                .WithMessage("Mobile No already exists.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MustAsync(async (email, cancellation) => !await _repository.IsEmailExistsAsync(email))
                .WithMessage("Email already exists.");
        }
    }
}
