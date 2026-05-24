using System.ComponentModel.DataAnnotations;

namespace TrainingTracker.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }

        [Required]
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; } = null!;

        [Required]
        public NotificationType NotificationType { get; set; }

        public DateTime SentDate { get; set; }
    }
}
