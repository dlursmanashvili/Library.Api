using Library.Models.Employee;

namespace Library.Infrastructure.Interfaces;

public interface IEmployeeRepository : IRepositoryBase<Employee>
{
    Task<Employee?> GetEmployeeByEmail(string Email);
}
