using AutoMapper;
using ERP.MVC.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ERP.MVC.Application.Commands.FinancialYears
{
    public class UpdateFinancialYearCommandHandler : IRequestHandler<UpdateFinancialYearCommand, string>
    {
        private readonly IFinancialYearRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateFinancialYearCommandHandler> _logger;

        public UpdateFinancialYearCommandHandler(IFinancialYearRepository repository, IMapper mapper, ILogger<UpdateFinancialYearCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> Handle(UpdateFinancialYearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var financialYear = await _repository.GetByIdAsync(cancellationToken, request.Id);
                if (financialYear == null)
                {
                    throw new Exception($"financialYear with ID {request.Id} not found.");
                }
                _mapper.Map(request, financialYear);
                await _repository.UpdateAsync(financialYear);
                return financialYear.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling UpdateFinancialYearCommand for FinancialYearName: {FinancialYearName}", request.FinancialYearName);
                throw;
            }
        }
    }
}
