namespace Library.Models.Models.Employee.CommandModel;

public class DeleteEmployeeRequest
{
    public Guid id { get; set; }
    public string AdminEmail { get; set; }
}
