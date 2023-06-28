using Library.Models.Models.AuthModels;
using Library.Service.IServices;
using Microsoft.AspNetCore.Mvc;


namespace Library.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthentification _authentification;
        public AuthController(IAuthentification authentification)
        {
            _authentification = authentification;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationRequest request) =>
             Ok(await _authentification.Register(request));

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(AuthRequest request) =>
            Ok(await _authentification.Login(request));
    }
}

