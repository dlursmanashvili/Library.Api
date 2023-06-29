using Microsoft.AspNetCore.Http;

namespace Library.Infrastructure.FileManagement
{
    public interface IFileService
    {
        Task<string> UploadFile(IFormFile file);
    }
}
