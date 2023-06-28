using Library.Infrastructure.HelperClass;
using Library.Models.Exceptions;
using Library.Models.Models.AuthModels;
using Library.Models.Models.Employee;
using Library.Service.IServices;

using Microsoft.Extensions.Configuration;

namespace Library.Service.Services;

public class Authentification : IAuthentification
{
    private readonly IEmployeeService _employeeService;
    private IConfiguration _icnfiguration { get; }
    public Authentification(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public async Task<AuthResult> Login(AuthRequest request)
    {
        var employee = await _employeeService.GetEmployeeByEmail(request.Email);
        if (employee == null)
            throw new NotFoundException($"Username with this '{request.Email}' not found.");

        if (!SecurityHelper.VerifyPasswordHash(request.Password, employee.PasswordHash, employee.PasswordSalt))
            throw new BadRequestException("InvalidPassword");

        return new AuthResult()
        {
            IsSuccess = true,
            AccessToken = Infrastructure.HelperClass.SecurityHelper.CreateToken(employee, _icnfiguration),
            SuccessMassage = "logged-in successfully"
        };
    }

    public async Task<AuthResponse> Register(RegistrationRequest request)
    {
        if (await _employeeService.GetEmployeeByEmail(request.Email) != null)
            throw new Exception($"ServiceEmail {request.Email} already exists.");

        SecurityHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

        await _employeeService.CreateEmployee(new Employee()
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            PasswordSalt = passwordSalt,
            PasswordHash = passwordHash,
            IsDeleted = false,
        });

        var currentUser = await _employeeService.GetEmployeeByEmail(request.Email);
        if (currentUser != null)
        {
            return new AuthResponse()
            {
                Id = currentUser.Id,
                Email = currentUser.Email,
            };
        }
        throw new Exception($"user not registered");
    }

}
