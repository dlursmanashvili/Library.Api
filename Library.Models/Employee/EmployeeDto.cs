using System.ComponentModel.DataAnnotations;

namespace Library.Models.Employee;

public class EmployeeDto
{   
    public string Email { get; set; }
    public string Password { get; set; }
}
