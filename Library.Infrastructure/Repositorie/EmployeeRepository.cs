using Library.Infrastructure.DataBaseHelper;
using Library.Infrastructure.Interfaces;
using Library.Models.Employee;

namespace Library.Infrastructure.Repositorie;

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
