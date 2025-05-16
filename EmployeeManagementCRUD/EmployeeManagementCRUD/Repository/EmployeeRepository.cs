using EmployeeManagementCRUD.Data;
using EmployeeManagementCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementCRUD.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Employee employee)
        {
            return _context.Database.ExecuteSqlRawAsync(
                "EXEC AddEmployee @FirstName = {0}, @LastName = {1}, @Email = {2}, @Department = {3}",
                employee?.FirstName ?? "", employee?.LastName ?? "", employee?.Email ?? "", employee?.Department ?? ""
                );
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC DeleteEmployee @Id = {0}", id
                );
        }

        public Task<List<Employee>> GetAllAsync()
        {
            return _context.employees
            .FromSqlRaw("EXEC GetAllEmployees")
            .ToListAsync();
        }

        public Employee? GetById(int id)
        {
            return _context.employees.FromSqlRaw("EXEC GetEmployeeById @Id = {0}", id)
                .AsEnumerable()
                .FirstOrDefault();
        }

        public Task UpdateAsync(Employee employee)
        {
            return _context.Database.ExecuteSqlRawAsync(
                 "EXEC UpdateEmployee @p0, @p1, @p2, @p3, @p4",
                employee.Id, employee.FirstName, employee.LastName, employee.Email, employee.Department);
        }
    }
}
