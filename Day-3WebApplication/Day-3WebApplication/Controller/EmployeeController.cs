using Day_3WebApplication.Contracts;
using Day_3WebApplication.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Day_3WebApplication.Controller
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController :ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository) 
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var employees = await _employeeRepository.GetEmployees();
                var employeeDtos = employees.Select(e => new EmployeeDTO
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                });

                return Ok(employeeDtos);
            }
            catch (Exception ex)
            { 
                return StatusCode(500, ex.Message);
            }
        }
    }
}
