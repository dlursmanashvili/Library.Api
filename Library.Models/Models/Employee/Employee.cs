using System.ComponentModel.DataAnnotations;

namespace Library.Models.Models.Employee;

public class Employee : BaseEntity<Guid>
{
    [Required]
    public string Email { get; set; }
    public bool IsAdministrator { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}
