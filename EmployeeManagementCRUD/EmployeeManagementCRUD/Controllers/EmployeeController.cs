using AutoMapper;
using EmployeeManagementCRUD.Data;
using EmployeeManagementCRUD.DTOs;
using EmployeeManagementCRUD.Models;
using EmployeeManagementCRUD.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        //private readonly AppDbContext _context;
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var employees = await _context.employees
            //    .FromSqlRaw("EXEC GetAllEmployees")
            //    .ToListAsync();
            var employees = await _repository.GetAllAsync();
            var employeesDto = _mapper.Map<List<EmployeeDto>>(employees);

            return Json(new { data = employeesDto });
        }

        [HttpGet]
        public IActionResult GetById(int Id)
        {
            //var employee = _context.employees
            //    .FromSqlRaw("EXEC GetEmployeeById @Id = {0}", Id)
            //    .AsEnumerable()
            //    .FirstOrDefault();
            var employee = _repository.GetById(Id);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employee != null
                ? Json(new { data = employeeDto })
                : Json(new { success = false });
        }

        [HttpPost("add")]
        //[HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false });

            //await _context.Database.ExecuteSqlRawAsync(
            //    "EXEC AddEmployee @FirstName = {0}, @LastName = {1}, @Email = {2}, @Department = {3}",
            //    employee?.FirstName??"", employee?.LastName??"", employee?.Email??"", employee?.Department??""
            //);
            var employee = _mapper.Map<Employee>(employeeDto);
            await _repository.AddAsync(employee);

            return Json(new { success = true });
        }

        //[HttpPost]
        [HttpPost("update")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                //await _context.Database.ExecuteSqlRawAsync(
                //    "EXEC UpdateEmployee @p0, @p1, @p2, @p3, @p4",
                //    employee.Id, employee.FirstName, employee.LastName, employee.Email, employee.Department);

                var employee = _mapper.Map<Employee>(employeeDto);
                await _repository.UpdateAsync(employee);

                return Json(new { success = true });
            }
            return Json(new { success = false });
        }


        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            //await _context.Database.ExecuteSqlRawAsync(
            //    "EXEC DeleteEmployee @Id = {0}", Id
            //);

            await _repository.DeleteAsync(Id);

            return Json(new { success = true });
        }
    }
}
