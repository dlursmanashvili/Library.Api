using Library.Infrastructure.HelperClass;
using Library.Infrastructure.Interfaces;
using Library.Models.Employee;
using Library.Service.IServices;
using Library.Service.Services;
using Microsoft.AspNetCore.Mvc;


namespace Library.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public IConfiguration _icnfiguration { get; }
        public AuthController(IConfiguration icnfiguration, IEmployeeService employeeService)
        {
            _icnfiguration = icnfiguration;
            _employeeService = employeeService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<EmployeeDto>> Register(EmployeeDto employee)
        {
            try
            {
                SecurityHelper.CreatePasswordHash(employee.Password, out byte[] passwordHash, out byte[] passwordSalt);
                var NewUser = new Employee()
                {
                    Id =  Guid.NewGuid(),
                    Email = employee.Email,
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash,
                    IsDeleted = false,
                };
                if (true)
                {

                }
                await _employeeService.CreateEmployee(NewUser);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<string>> Login(EmployeeDto request)
        {
            var employee = await _employeeService.GetEmployeeByEmail(request.Email);
            if (employee == null)
            {
                return BadRequest("user Not found");
            }
            if (!SecurityHelper.VerifyPasswordHash(request.Password, employee.PasswordHash, employee.PasswordSalt))
            {
                return BadRequest("Password not correct");
            }
            return Ok(SecurityHelper.CreateToken(employee, _icnfiguration));
        }

    }

}

