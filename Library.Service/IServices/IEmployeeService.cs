using Library.Models.Models.Employee;

namespace Library.Service.IServices;

public interface IEmployeeService
{
    Task CreateEmployee(Employee user);
    Task UpdateEmployee(Employee user);
    Task DeleteEmployee(Employee user);
    Task<Employee> GetEmployeeById(Guid id);
    Task<Employee?> GetEmployeeByEmail(string Email);
    Task<IEnumerable<Employee>> GetAllEmployee();
}
