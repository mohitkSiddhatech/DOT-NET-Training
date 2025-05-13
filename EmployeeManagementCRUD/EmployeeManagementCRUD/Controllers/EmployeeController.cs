using EmployeeManagementCRUD.Data;
using EmployeeManagementCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;
        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _context.employees
                .FromSqlRaw("EXEC GetAllEmployees")
                .ToListAsync();

            return Json(new { data = employees });
        }

        [HttpGet]
        public IActionResult GetById(int Id)
        {
            var employee = _context.employees
                .FromSqlRaw("EXEC GetEmployeeById @Id = {0}", Id)
                .AsEnumerable()
                .FirstOrDefault();

            return employee != null
                ? Json(new { data = employee })
                : Json(new { success = false });
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false });

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC AddEmployee @FirstName = {0}, @LastName = {1}, @Email = {2}, @Department = {3}",
                employee?.FirstName??"", employee?.LastName??"", employee?.Email??"", employee?.Department??""
            );

            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false });

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC UpdateEmployee @Id = {0}, @FirstName = {1}, @LastName = {2}, @Email = {3}, @Department = {4}",
                employee.Id, employee?.FirstName??"", employee?.LastName??"", employee?.Email??"", employee?.Department??""
            );

            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC DeleteEmployee @Id = {0}", Id
            );

            return Json(new { success = true });
        }
    }
}
