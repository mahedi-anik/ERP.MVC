using AutoMapper;
using ERP.MVC.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ERP.MVC.Application.Commands.AccountSubHeadTypes
{
    public class UpdateAccountSubHeadTypeCommandHandler : IRequestHandler<UpdateAccountSubHeadTypeCommand, string>
    {
        private readonly IAccountSubHeadTypeRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateAccountSubHeadTypeCommandHandler> _logger;

        public UpdateAccountSubHeadTypeCommandHandler(IAccountSubHeadTypeRepository repository, IMapper mapper, ILogger<UpdateAccountSubHeadTypeCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<string> Handle(UpdateAccountSubHeadTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var accountSubHeadType = await _repository.GetByIdAsync(cancellationToken, request.Id);
                if (accountSubHeadType == null)
                {
                    throw new Exception($"accountSubHeadType with ID {request.Id} not found.");
                }
                _mapper.Map(request, accountSubHeadType);
                await _repository.UpdateAsync(accountSubHeadType);
                return accountSubHeadType.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling UpdateFinancialYearCommand for AccountSubHeadTypeName: {AccountSubHeadTypeName}", request.AccountSubHeadTypeName);
                throw;
            }
        }
    }
}
