namespace Library.Models.Models.Employee.CommandModel;

public class GetEmployeeResponse
{
    public Guid id { get; set; }
    public string AdminEmail { get; set; }
    public bool IsAdministrator { get; set; }
}
