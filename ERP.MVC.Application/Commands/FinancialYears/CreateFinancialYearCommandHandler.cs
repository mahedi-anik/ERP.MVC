using AutoMapper;
using ERP.MVC.Application.Models;
using ERP.MVC.Domain.Entities.MasterData;
using ERP.MVC.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ERP.MVC.Application.Commands.FinancialYears
{
    public class CreateFinancialYearCommandHandler : IRequestHandler<CreateFinancialYearCommand, Result<string>>
    {
        private readonly IValidator<CreateFinancialYearCommand> _validator;
        private readonly IFinancialYearRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateFinancialYearCommandHandler> _logger;
        public CreateFinancialYearCommandHandler(
            IValidator<CreateFinancialYearCommand> validator,
            IFinancialYearRepository repository,
            IMapper mapper,
            ILogger<CreateFinancialYearCommandHandler> logger)
        {
            _validator = validator;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<string>> Handle(CreateFinancialYearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return Result<string>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                var financialYear = _mapper.Map<FinancialYear>(request);
                financialYear.CreatedBy = "CurrentUser Id";
                await _repository.AddAsync(financialYear);
                return Result<string>.Success(financialYear.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling CreateFinancialYearCommand for FinancialYearName: {FinancialYearName}", request.FinancialYearName);
                throw;
            }
        }
    }
}
