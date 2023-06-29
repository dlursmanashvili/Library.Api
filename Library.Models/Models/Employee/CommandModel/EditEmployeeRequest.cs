namespace Library.Models.Models.Employee.CommandModel;

public class EditEmployeeRequest
{
    public bool IsAdministrator { get; set; }
    public string UserEmamail { get; set; }
    public Guid UserID { get; set; }
    public string AdminEmail { get; set; }
    public bool IsDeleted { get; set; }
}
