using Library.Models.Models.Employee;

namespace Library.Infrastructure.Repositories.Interfaces;

public interface IEmployeeRepository : IRepositoryBase<Employee>
{
    Task<Employee?> GetEmployeeByEmail(string Email);
}
