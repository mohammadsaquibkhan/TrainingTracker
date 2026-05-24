using System.ComponentModel.DataAnnotations;

namespace TrainingTracker.Models
{
    public class Certificate
    {
        [Key]
        public int CertificateId { get; set; }

        [Required]
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; } = null!;

        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        [Required]
        public int TrainingId { get; set; }
        public Training Training { get; set; } = null!;

        public DateTime IssueDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string CertificateNumber { get; set; } = null!;
    }
}
