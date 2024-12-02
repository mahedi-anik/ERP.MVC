using AutoMapper;
using ERP.MVC.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ERP.MVC.Application.Commands.AccountHeadTypes
{
    public class UpdateAccountHeadTypeCommandHandler : IRequestHandler<UpdateAccountHeadTypeCommand, string>
    {
        private readonly IAccountHeadTypeRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateAccountHeadTypeCommandHandler> _logger;

        public UpdateAccountHeadTypeCommandHandler(IAccountHeadTypeRepository repository, IMapper mapper, ILogger<UpdateAccountHeadTypeCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> Handle(UpdateAccountHeadTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var accountHeadType = await _repository.GetByIdAsync(request.Id, cancellationToken);
                if (accountHeadType == null)
                {
                    throw new Exception($"accountHeadType with ID {request.Id} not found.");
                }
                _mapper.Map(request, accountHeadType);
                await _repository.UpdateAsync(accountHeadType);
                return accountHeadType.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling UpdateFinancialYearCommand for AccountHeadTypeName: {AccountHeadTypeName}", request.AccountHeadTypeName);
                throw;
            }
        }
    }
}
