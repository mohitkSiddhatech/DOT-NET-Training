using Day_3WebApplication.Entities;

namespace Day_3WebApplication.Contracts
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetEmployees();
    }
}
