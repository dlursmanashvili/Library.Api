using Library.Infrastructure.Interfaces;
using Library.Models.Employee;

namespace Library.Service.Services;

public class EmployeeService
{

    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task CreateEmployee(Employee user)
    {
        await _employeeRepository.AddAsync(user);
    }

    public async Task<Employee> GetEmployeeById(Guid id)
    {
        return await _employeeRepository.GetByIdAsync(id);
    }

    public async Task<Employee?> GetEmployeeByEmail(string Email)
    {
        var users = await GetAllEmployee();
        return users.FirstOrDefault(x => x.Email == Email);
    }
    public async Task<IEnumerable<Employee>> GetAllEmployee()
    {
        return await _employeeRepository.LoadAsync();
    }

    public async Task UpdateEmployee(Employee user)
    {
        await _employeeRepository.UpdateAsync(user);
    }

    public async Task DeleteEmployee(Employee user)
    {
        await _employeeRepository.RemoveAsync(user);
    }

}
