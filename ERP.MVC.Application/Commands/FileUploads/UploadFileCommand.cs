using ERP.MVC.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ERP.MVC.Application.Commands.FileUploads
{
    public class UploadFileCommand : IRequest<Result<string>>
    {
        public IFormFile File { get; set; }
        public string EntityId { get; set; } 
    }
}
