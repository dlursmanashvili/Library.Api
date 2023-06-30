using Microsoft.AspNetCore.Http;

namespace Library.Service.FileManagement
{
    public interface IFileService
    {
        Task<string> UploadFile(IFormFile file);
    }
}
