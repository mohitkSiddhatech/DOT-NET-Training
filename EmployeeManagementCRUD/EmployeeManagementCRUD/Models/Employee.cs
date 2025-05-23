using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementCRUD.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Department { get; set; }
    }
}
