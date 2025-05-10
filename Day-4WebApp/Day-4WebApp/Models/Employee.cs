using System.ComponentModel.DataAnnotations;

namespace Day_4WebApp.Models
{
    public class Employee
    {
        [Key]
        public int  Id { get; set; }
        [Required]
        [StringLength (50)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }
        public string? Email { get; set; }
        
    }
}
