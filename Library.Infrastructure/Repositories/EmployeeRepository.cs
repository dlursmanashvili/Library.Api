using Library.Infrastructure.Db;
using Library.Infrastructure.Interfaces;
using Library.Models.Employee;

namespace Library.Infrastructure.Repositories;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext context) : base(context)
    {
    }
}
