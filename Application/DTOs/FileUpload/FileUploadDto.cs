using Microsoft.AspNetCore.Http;

namespace Application.DTOs.FileUpload
{
    public class FileUploadDto
    {
        public string FilePath { get; set; }

        public List<IFormFile> Files { get; set; }
    }
}
