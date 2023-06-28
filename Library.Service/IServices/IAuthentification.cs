using Library.Models.Models.AuthModels;

namespace Library.Service.IServices;

public interface IAuthentification
{
    Task<AuthResult> Login(AuthRequest request);
    Task<AuthResponse> Register(RegistrationRequest request);
}
