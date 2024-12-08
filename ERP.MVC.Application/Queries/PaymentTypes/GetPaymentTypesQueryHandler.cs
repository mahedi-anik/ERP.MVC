using AutoMapper;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Domain.Interfaces;
using MediatR;

namespace ERP.MVC.Application.Queries.PaymentTypes
{
    public class GetPaymentTypesQueryHandler : IRequestHandler<GetPaymentTypesQuery, List<PaymentTypeDto>>
    {
        private readonly IPaymentTypeRepository _repository;
        private readonly IMapper _mapper;

        public GetPaymentTypesQueryHandler(IPaymentTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<PaymentTypeDto>> Handle(GetPaymentTypesQuery request, CancellationToken cancellationToken)
        {
            var paymentTypes = await _repository.GetAllAsync(
              cancellationToken);
            return _mapper.Map<List<PaymentTypeDto>>(paymentTypes);
        }
    }
}
