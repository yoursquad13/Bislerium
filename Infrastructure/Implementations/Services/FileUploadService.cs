using Application.Interfaces.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Entities.Utility;

namespace Infrastructure.Implementations.Services
{
    public class FileUploadService(IWebHostEnvironment webHostEnvironment) : IFileUploadService
    {
        public string UploadDocument(string uploadedFilePath, IFormFile file)
        {
            if (!Directory.Exists(Path.Combine(webHostEnvironment.WebRootPath, uploadedFilePath)))
            {
                Directory.CreateDirectory(Path.Combine(webHostEnvironment.WebRootPath, uploadedFilePath));
            }

            var uploadedDocumentPath = Path.Combine(webHostEnvironment.WebRootPath, uploadedFilePath);

            var fileName = UploadFile(uploadedDocumentPath, file);

            return fileName;
        }

        private static string UploadFile(string uploadedFilePath, IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);

            var fileName = extension.SetUniqueFileName();

            using var stream = new FileStream(Path.Combine(uploadedFilePath, fileName), FileMode.Create);

            file.CopyTo(stream);

            return fileName;
        }
    }
}
