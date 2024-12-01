using ERP.MVC.Domain.Interfaces;
using FluentValidation;

namespace ERP.MVC.Application.Commands.FinancialYears
{
    public class CreateFinancialYearCommandValidator : AbstractValidator<CreateFinancialYearCommand>
    {
        private readonly IFinancialYearRepository _repository;

        public CreateFinancialYearCommandValidator(IFinancialYearRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage("Company ID is required.");

            RuleFor(x => x.FinancialYearName)
                .MustAsync(async (command, financialYearName, cancellation) =>
                    {
                        return !await _repository.IsFinancialYearExistAsync(
                                command.CompanyId, financialYearName, command.StartDate, command.EndDate);
                    })
                .WithMessage("Financial Year Name already exists.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start Date is required.");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End Date is required.");

            RuleFor(x => x)
                .Must(command => command.EndDate > command.StartDate)
                .WithMessage("End Date must be later than Start Date.");
        }
    }
}
