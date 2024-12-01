using AutoMapper;
using ERP.MVC.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ERP.MVC.Application.Commands.TransactionHeads
{
    public class UpdateTransactionHeadCommandHandler : IRequestHandler<UpdateTransactionHeadCommand, string>
    {
        private readonly ITransactionHeadRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateTransactionHeadCommandHandler> _logger;

        public UpdateTransactionHeadCommandHandler(ITransactionHeadRepository repository, IMapper mapper, ILogger<UpdateTransactionHeadCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<string> Handle(UpdateTransactionHeadCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var transactionHead = await _repository.GetByIdAsync(cancellationToken, request.Id);
                if (transactionHead == null)
                {
                    throw new Exception($"transactionHead with ID {request.Id} not found.");
                }
                _mapper.Map(request, transactionHead);
                await _repository.UpdateAsync(transactionHead);
                return transactionHead.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling UpdateTransactionHeadCommand for TransactionHeadName: {TransactionHeadName}", request.TransactionHeadName);
                throw;
            }
        }
    }
}
