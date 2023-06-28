using Library.Infrastructure.Repositories.Interfaces;
using Library.Models.Exceptions;
using Library.Models.Models.Employee;
using Library.Service.IServices;

namespace Library.Service.Services;

public class EmployeeService : IEmployeeService
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
        var Result = await _employeeRepository.GetEmployeeByEmail(Email);
        if (Result == null) throw new NotFoundException("user Not found");

       return Result;
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
