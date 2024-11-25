using ERP.MVC.Domain.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ERP.MVC.Infrastructure.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly string _wwwRootPath;

        public FileUploadService(IHostingEnvironment hostingEnvironment)
        {
            _wwwRootPath = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
        }

        public async Task<string> UploadFileAsync(IFormFile file, EntityType entityType)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File cannot be null or empty");

            var folderPath = Path.Combine(_wwwRootPath, entityType.ToString());
            Directory.CreateDirectory(folderPath); // Create directory if it doesn't exist

            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Return the relative file path to the file (to be used in the URL)
            return Path.Combine("uploads", entityType.ToString(), fileName);
        }

        public async Task DeleteFileAsync(string filePath)
        {
            var fullPath = Path.Combine(_wwwRootPath, filePath);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }

}
