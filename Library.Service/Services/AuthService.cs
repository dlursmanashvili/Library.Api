using Library.Infrastructure.Interfaces;
using Library.Models.AuthModels;
using Library.Service.IServices;

namespace Library.Service.Services;

public class AuthService : IAuthService
{
    #region Constructor

    private readonly IEmployeeRepository _repository;
    public AuthService(IEmployeeRepository repository)
    {
        _repository = repository;
    }
    #endregion
    public async Task<AuthResponse> Register(RegistrationRequest request)
    {       
        //check email
        var existingEmail = await   _repository.GetEmployeeByEmail(request.Email);
        if (existingEmail != null)
            throw new Exception($"ServiceEmail {request.Email} already exists.");


        var roleName = await GetRoleName(request.RoleId);

        var user = new User
        {
            Email = request.Email,
            UserName = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
            EmailConfirmed = true
        };


        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            //Assign role to the user.
            await _userManager.AddToRoleAsync(user, roleName);

            var currentUser = await _userManager.FindByEmailAsync(user.Email);

            return new AuthResponse()
            {
                Id = currentUser.Id,
                UserName = currentUser.UserName,
                Email = currentUser.Email,
            };
        }

        throw new Exception($"{result.Errors.FirstOrDefault().Description}");
    }

    public Task<AuthResult> Login(AuthRequest request)
    {
        throw new NotImplementedException();
    }

}
