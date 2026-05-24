using System.ComponentModel.DataAnnotations;

namespace TrainingTracker.Models
{
    public class Training
    {
        [Key]
        public int TrainingId { get; set; }

        [Required]
        [MaxLength(50)]
        public string TrainingCode { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        public TrainingType Type { get; set; }

        public int DurationHours { get; set; }

        public string? Prerequisites { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
        public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
    }
}
