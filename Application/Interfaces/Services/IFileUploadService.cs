using Microsoft.AspNetCore.Http;

namespace Application.Interfaces.Services
{
    public interface IFileUploadService
    {
        string UploadDocument(string uploadedFilePath, IFormFile file);
    }
}
