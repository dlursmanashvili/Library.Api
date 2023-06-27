using Library.Infrastructure.HelperClass;
using Library.Models.Employee;
using Library.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Library.Controller;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly EmployeeService _employeeService;
    public IConfiguration _icnfiguration { get; }
    public AuthController(IConfiguration icnfiguration)
    {
        _icnfiguration = icnfiguration;
    }

    [HttpPost("register")]
    public async Task<ActionResult<EmployeeDto>> Register(EmployeeDto employee)
    {
        try
        {
            SecurityHelper.CreatePasswordHash(employee.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var NewUser = new Employee()
            {
                Id = new Guid(),
                Email = employee.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                IsDeleted = false,
            };
            await _employeeService.CreateEmployee(NewUser);
            return Ok(employee);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(EmployeeDto request)
    {
        var employee = await _employeeService.GetEmployeeByEmail(request.Email);
        if (employee == null)
        {
            return BadRequest("user Not found");
        }
        if (!SecurityHelper.VerifyPasswordHash(request.Password, employee.PasswordHash, employee.PasswordSalt))
        {
            return BadRequest("Password not correct");
        }
        return Ok(SecurityHelper.CreateToken(employee));
    }

}
