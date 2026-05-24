using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingTracker.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = null!;

        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        [MaxLength(200)]
        public string JobTitle { get; set; } = null!;

        public int? ManagerId { get; set; }
        public Employee? Manager { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Phone]
        public string? PhoneNumber { get; set; }

        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
        public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
    }
}
