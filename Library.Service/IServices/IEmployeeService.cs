using Library.Models;
using Library.Models.Models.Employee;
using Library.Models.Models.Employee.CommandModel;

namespace Library.Service.IServices;

public interface IEmployeeService
{
    Task<CoommandResult> CreateEmployee(Employee user);
    Task<CoommandResult> UpdateEmployee(EditEmployeeRequest editEmployeeRequest);
    Task<CoommandResult> DeleteEmployee(DeleteEmployeeRequest deleteEmployeeRequest);
    Task<GetEmployeeResponse> GetEmployeeById(Guid id);
    Task<IEnumerable<GetEmployeeResponse>?> GetAllEmployee(string AdminEmail);
    Task<Employee?> GetEmployeeByEmail(string Email);
}
