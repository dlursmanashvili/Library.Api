using Library.Infrastructure.HelperClass;
using Library.Infrastructure.Repositories.Interfaces;
using Library.Models;
using Library.Models.Models.Employee;
using Library.Models.Models.Employee.CommandModel;
using Library.Service.IServices;
using System.Linq;

namespace Library.Service.Services;

public class EmployeeService : IEmployeeService
{

    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<CoommandResult> CreateEmployee(Employee user)
    {
        await _employeeRepository.AddAsync(user);
        return new CoommandResult();
    }
    public async Task<CoommandResult> UpdateEmployee(EditEmployeeRequest editEmployeeRequest)
    {
        var user = await _employeeRepository.GetEmployeeByEmail(editEmployeeRequest.AdminEmail);
        ValidationHelper.UserValidation(user, editEmployeeRequest.AdminEmail, true);

        var UpdateItem = await _employeeRepository.GetByIdAsync(editEmployeeRequest.UserID);
        if (UpdateItem == null)
            throw new Exception("userNotFound");

        UpdateItem.IsAdministrator = editEmployeeRequest.IsAdministrator;
        UpdateItem.Email = editEmployeeRequest.UserEmamail;
        UpdateItem.IsDeleted = editEmployeeRequest.IsDeleted;              

        await _employeeRepository.UpdateAsync(UpdateItem);
        return new CoommandResult();
    }

    public async Task<CoommandResult> DeleteEmployee(DeleteEmployeeRequest deleteEmployeeRequest)
    {
        var user = await _employeeRepository.GetEmployeeByEmail(deleteEmployeeRequest.AdminEmail);
        if (user.Email == "SuperAdmin@gmail.com")
        {
            throw new Exception("SuperAdmin@gmail.com not deleted");
        }
        ValidationHelper.UserValidation(user, deleteEmployeeRequest.AdminEmail, true);

        var RemoveItem = await _employeeRepository.GetByIdAsync(deleteEmployeeRequest.id);
        await _employeeRepository.RemoveAsync(RemoveItem);
        return new CoommandResult();
    }

    public async Task<GetEmployeeResponse?> GetEmployeeById(Guid id)
    {
        var user = await _employeeRepository.GetByIdAsync(id);
        if (user == null)
        {
           throw  new Exception("user not found");
        }
        else
        {
            return new GetEmployeeResponse()
            {
                AdminEmail = user.Email,
                id = user.Id,
                IsAdministrator = user.IsAdministrator,
            };
        }
    }

    public async Task<IEnumerable<GetEmployeeResponse>?> GetAllEmployee(string Email)
    {
        var user = await _employeeRepository.GetEmployeeByEmail(Email);
        ValidationHelper.UserValidation(user, Email, true);
        var resultList = await _employeeRepository.LoadAsync();
        if (resultList.Any())
        {
            return resultList.Select(x => new GetEmployeeResponse()
            {
                AdminEmail = x.Email,
                id = x.Id,
                IsAdministrator = x.IsAdministrator
            }).ToList();
        }
        else
        {
            return null;
        }
        
    }
    public async Task<Employee?> GetEmployeeByEmail(string Email)
    {
        var user = await _employeeRepository.GetEmployeeByEmail(Email);
        if (user == null)
        {
            throw new Exception("user not found");
        }

        return user;
    }
}
