using System.ComponentModel.DataAnnotations;

namespace Library.Models;

public class Employee : BaseEntity<Guid>
{
    public string Firstname { get; set; }
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }
    [Required]
    public string Password { get; set; }    
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}
