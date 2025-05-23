using CRUDWITHRELATIONSHIPS.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDWITHRELATIONSHIPS.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> department { get; set; }
    }
}
