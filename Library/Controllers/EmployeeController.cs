using Library.Models.Models.Employee.CommandModel;
using Library.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeById(Guid id)
        => Ok(await _employeeService.GetEmployeeById(id));


    [HttpGet("{AdminEmail}")]    
    public async Task<IActionResult> GetAllEmployees(string AdminEmail)
        => Ok(await _employeeService.GetAllEmployee(AdminEmail));

    [HttpPut]
    public async Task<IActionResult> UpdateEmployee(EditEmployeeRequest editEmployeeRequest)
        => Ok(await _employeeService.UpdateEmployee(editEmployeeRequest));


    [HttpDelete]
    public async Task<IActionResult> DeleteEmployee(DeleteEmployeeRequest deleteEmployeeRequest)
        => Ok(await _employeeService.DeleteEmployee(deleteEmployeeRequest));

}
