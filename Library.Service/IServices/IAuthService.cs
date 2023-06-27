using Library.Models.AuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.IServices;

public interface IAuthService
{
    Task<AuthResult> Login(AuthRequest request);
    Task<AuthResponse> Register(RegistrationRequest request);

}
