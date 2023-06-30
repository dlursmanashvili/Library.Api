using Library.Models.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Library.Service.FileManagement;
public class FileService : IFileService
{
    public async Task<string> UploadFile(IFormFile file)
    {
        // validate if file is null or exceeds defined max size.
        #region Validations
        var maxSizeInMbs = 5;

        if (file is null)
            throw new BadRequestException("file empty");

        if (file.Length > maxSizeInMbs << 20)
            throw new BadRequestException($"File size exceeds {maxSizeInMbs} Mb's.");
        #endregion

        var extension = Path.GetExtension(file.FileName);
        var fileName = Guid.NewGuid().ToString();

        // directory path - destination, where uploaded file will be stored.
        // ensure if folder exists or not, if not- create it.
        var directoryPath = @"C:\Users\MyWorkOffice\Desktop\test\";
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        var filePath = Path.Combine(directoryPath, fileName + extension);
        using Stream fileStream = new FileStream(filePath, FileMode.Create);

        await file.CopyToAsync(fileStream);

        return GetServerRelativePath(directoryPath, fileName, extension);
    }

    #region PrivateMethods
    private string GetServerRelativePath(string directoryPath, string fileName, string extension)
    {
        return Path.Combine(directoryPath + fileName + extension);
    }
    #endregion
}

