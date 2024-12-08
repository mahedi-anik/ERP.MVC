using ERP.MVC.Application.DTOs;
using MediatR;

namespace ERP.MVC.Application.Queries.PaymentTypes
{
    public class GetPaymentTypesQuery : IRequest<List<PaymentTypeDto>>
    {
    }
}
