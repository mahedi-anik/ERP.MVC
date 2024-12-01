using ERP.MVC.Application.Models;
using ERP.MVC.Domain.Entities.Auth;
using ERP.MVC.Domain.Entities.MasterData;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.MVC.Application.Commands.TransactionHeads
{
    public class CreateTransactionHeadCommand : IRequest<Result<string>>
    {
        public string? CompanyId { get; set; }
        public string? BranchId { get; set; }
        public string? AccountHeadTypeId { get; set; }
        public string? AccountSubHeadTypeId { get; set; }
        public string? TransactionHeadName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
