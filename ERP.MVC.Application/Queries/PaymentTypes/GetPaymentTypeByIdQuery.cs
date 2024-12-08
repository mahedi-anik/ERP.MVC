using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.PaymentTypes
{
    public class GetPaymentTypeByIdQuery : IRequest<PaymentTypeDto>
    {
        public string Id { get; set; }
    }
}
