using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.PaymentTypes
{
    public class GetPaymentTypeByIdQueryHandler : IRequestHandler<GetPaymentTypeByIdQuery, PaymentTypeDto>
    {
        private readonly IPaymentTypeRepository _repository;
        private readonly IMapper _mapper;

        public GetPaymentTypeByIdQueryHandler(IPaymentTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PaymentTypeDto> Handle(GetPaymentTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var paymentType = await _repository.GetByIdAsync(request.Id, cancellationToken);
            return _mapper.Map<PaymentTypeDto>(paymentType);
        }
    }
}
