using EmployeeManagementCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementCRUD.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // We can intereatct with the Employee table in DB with this object in the code further.
        public DbSet<Employee> employees { get; set; }
    }
}
