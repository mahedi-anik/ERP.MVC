using ERP.MVC.Application.Models;
using MediatR;

namespace ERP.MVC.Application.Commands.PaymentTypes
{
    public class CreatePaymentTypeCommand : IRequest<Result<string>>
    {
        public string? PaymentTypeName { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
