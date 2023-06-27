using Library.Models.Employee;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Library.Infrastructure.HelperClass;

public static class SecurityHelper
{

    public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computerHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computerHash.Equals(passwordHash);
        }

    }
    public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }

    public static string CreateToken(Employee user)
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
