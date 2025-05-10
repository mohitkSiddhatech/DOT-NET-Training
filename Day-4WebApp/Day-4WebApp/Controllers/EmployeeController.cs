using Day_4WebApp.Data;
using Day_4WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day_4WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeController(AppDbContext context) 
        {
            _appDbContext = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> employees = _appDbContext.employees.ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add([Bind("FirstName, LastName, Email")]Employee employee)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.employees.Add(employee);
                _appDbContext.SaveChanges();
                TempData["Notification"] = "Employee Added Successfully";
                TempData["NotificationType"] = "success";
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var employee = _appDbContext.employees.Find(Id);
            if(employee == null)
            {
                return NotFound();
            }
            else
            {
                return View(employee);
            }
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id, FirstName, LastName, Email")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.employees.Update(employee);
                _appDbContext.SaveChanges();
                TempData["Notification"] = "Employee Added Successfully";
                TempData["NotificationType"] = "success";
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var employee = _appDbContext.employees.Find(Id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return View(employee);
            }
        }

        [HttpPost]
        public IActionResult DeleteEmployee(int Id)
        {
            var employee = _appDbContext.employees.Find(Id);
            if (employee == null)
            {
                return NotFound();
            }

            _appDbContext.employees.Remove(employee);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
