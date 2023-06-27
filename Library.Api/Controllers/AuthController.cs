using Library.Models.Employee;
using Library.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
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
            CreatePasswordHash(employee.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var NewUser = new Employee()
            {
                Id = new Guid(),
                Email = employee.Email,
                Password = employee.Password,
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
        var users = await _employeeService.GetAllEmployee();

        var employee =  users.FirstOrDefault(x => x.Email == request.Email);
        if (employee == null)
        {
            return BadRequest("user Not found");
        }
        if (!VerifyPasswordHash(request.Password,employee.PasswordHash,employee.PasswordSalt))
        {
            return BadRequest("Password not correct");
        }
        return Ok("successful");
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computerHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computerHash.Equals(passwordHash);
        }
           
    }
    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }

    private string CreateToken(Employee user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name,user.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_icnfiguration.GetSection("AppSetting:Token").Value));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
