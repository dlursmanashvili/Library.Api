using Library.Models;
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

    public IConfiguration _icnfiguration { get; }
    public static Employee user = new Employee();
    public AuthController(IConfiguration icnfiguration)
    {
        _icnfiguration = icnfiguration;
    }

    [HttpPost("register")]
    public async Task<ActionResult<Employee>> Register(Employee employee)
    {
        CreatePasswordHash(employee.Password, out byte[] passwordHash, out byte[] passwordSalt);

        user.Email = employee.Email;
        user.Password = employee.Password;
        user.PasswordSalt = passwordSalt;
        user.PasswordHash = passwordHash;
        user.LastName = employee.LastName;
        user.Firstname = employee.Firstname;
        user.BirthDate = employee.BirthDate;
        user.IsDeleted = employee.IsDeleted;
        return Ok(user);
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
            new Claim(ClaimTypes.Name,user.Firstname)
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
