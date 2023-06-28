using Library.Infrastructure.DataBaseHelper;
using Library.Infrastructure.Repositories.Interfaces;
using Library.Models.Models.Employee;

namespace Library.Infrastructure.Repositories.Repository;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Employee?> GetEmployeeByEmail(string Email)
    {
        return _context.Employees.FirstOrDefault(x => x.Email == Email);
    }
}
