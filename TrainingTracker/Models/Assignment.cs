using System.ComponentModel.DataAnnotations;

namespace TrainingTracker.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        [Required]
        public int TrainingId { get; set; }
        public Training Training { get; set; } = null!;

        public DateTime AssignedDate { get; set; }
        public DateTime DeadlineDate { get; set; }

        [Required]
        public AssignmentStatus Status { get; set; }

        public DateTime? CompletionDate { get; set; }

        public Certificate? Certificate { get; set; }
    }
}
