using Library.Infrastructure.Interfaces;
using Library.Models.AuthModels;
using Library.Service.IServices;

namespace Library.Service.Services;

public class AuthService : IAuthService
{

    private readonly IEmployeeRepository _repository;
    public AuthService(IEmployeeRepository repository)
    {
        _repository = repository;
    }
    

    public Task<AuthResult> Login(AuthRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<AuthResponse> Register(RegistrationRequest request)
    {
        throw new NotImplementedException();
    }
}