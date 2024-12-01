using ERP.MVC.Domain.Interfaces;
using FluentValidation;

namespace ERP.MVC.Application.Commands.TransactionHeads
{
    public class CreateTransactionHeadCommandValidator : AbstractValidator<CreateTransactionHeadCommand>
    {
        private readonly ITransactionHeadRepository _repository;

        public CreateTransactionHeadCommandValidator(ITransactionHeadRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage("Company ID is required.");

            RuleFor(x => x.BranchId)
                .NotEmpty().WithMessage("BranchId is required.");

            RuleFor(x => x.AccountHeadTypeId)
                .NotEmpty().WithMessage("AccountHeadTypeId is required.");

            RuleFor(x => x.AccountSubHeadTypeId)
                .NotEmpty().WithMessage("AccountSubHeadTypeId is required.");

            RuleFor(x => x.TransactionHeadName)
                .MustAsync(async (command, transactionHeadName, cancellation) =>
                {
                    return !await _repository.IsTransactionHeadExistAsync(
                            command.CompanyId, command.BranchId, command.AccountHeadTypeId, command.AccountSubHeadTypeId, transactionHeadName);
                })
                .WithMessage("TransactionHeadName already exists.");


        }
    }
}
