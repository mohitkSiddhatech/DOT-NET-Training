using System.ComponentModel.DataAnnotations;

namespace CRUDWITHRELATIONSHIPS.Models
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
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
