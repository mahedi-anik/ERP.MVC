using ERP.MVC.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ERP.MVC.Application.Commands.FileUploads
{
    public class UploadFilesCommand : IRequest<Result<List<string>>>
    {
        public List<IFormFile> Files { get; set; }
        public string EntityId { get; set; } // For identifying the entity (e.g., Company)
    }
}
