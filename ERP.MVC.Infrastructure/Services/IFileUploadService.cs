using ERP.MVC.Domain.Entities.Enums;
using Microsoft.AspNetCore.Http;

namespace ERP.MVC.Infrastructure.Services
{
    public interface IFileUploadService
    {
        Task<string> UploadFileAsync(IFormFile file, EntityType entityType);
        Task DeleteFileAsync(string filePath);
    }
}
