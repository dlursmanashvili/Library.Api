using System.ComponentModel.DataAnnotations;

namespace Library.Models.Employee;

public class Employee : BaseEntity<Guid>
{   
    [Required]
    public string Email { get; set; } 
    [Required]
    public string Password { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}
