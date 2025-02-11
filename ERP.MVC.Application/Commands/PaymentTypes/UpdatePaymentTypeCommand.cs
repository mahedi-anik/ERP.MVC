using MediatR;

namespace ERP.MVC.Application.Commands.PaymentTypes
{
    public class UpdatePaymentTypeCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string? PaymentTypeName { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
