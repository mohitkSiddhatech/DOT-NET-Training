using Dapper;
using Day_3WebApplication.Context;
using Day_3WebApplication.Contracts;
using Day_3WebApplication.Entities;

namespace Day_3WebApplication.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _context;

        public EmployeeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var procedureName = "GetEmployees";
            using (var connection = _context.CreateConnection())
            {
                var employees = await connection.QueryAsync<Employee>(
                    procedureName,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return employees.ToList();
            }
        }
    }
}
