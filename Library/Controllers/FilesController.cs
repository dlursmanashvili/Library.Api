using Library.Service.FileManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        #region Controller
        private readonly IFileService _service;
        public FilesController(IFileService service)
        {
            _service = service;
        }

        #endregion
        [Authorize]
        [HttpPost()]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            //returns Path
            var result = await _service.UploadFile(file);

            return Ok(result);
        }
    }

}
