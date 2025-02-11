using AutoMapper;
using ERP.MVC.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ERP.MVC.Application.Commands.PaymentTypes
{
    public class UpdatePaymentTypeCommandHandler : IRequestHandler<UpdatePaymentTypeCommand, string>
    {
        private readonly IPaymentTypeRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdatePaymentTypeCommand> _logger;

        public UpdatePaymentTypeCommandHandler(IPaymentTypeRepository repository, IMapper mapper, ILogger<UpdatePaymentTypeCommand> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> Handle(UpdatePaymentTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var paymentType = await _repository.GetByIdAsync(request.Id, cancellationToken);
                if (paymentType == null)
                {
                    throw new Exception($"PaymentType with ID {request.Id} not found.");
                }

                _mapper.Map(request, paymentType);
                await _repository.UpdateAsync(paymentType);
                return paymentType.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling UpdatePaymentTypeCommand for PaymentTypeyName: {PaymentTypeName}", request.PaymentTypeName);
                throw;
            }
        }
    }
}
