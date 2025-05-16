using EmployeeManagementCRUD.Models;

namespace EmployeeManagementCRUD.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Employee? GetById(int id);
        Task AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);

    }
}
