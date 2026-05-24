namespace TrainingTracker.Models
{
    public enum TrainingType
    {
        Mandatory,
        Optional
    }

    public enum AssignmentStatus
    {
        NotStarted,
        InProgress,
        Completed,
        Overdue
    }

    public enum NotificationType
    {
        DeadlineApproaching,
        Overdue,
        Renewal
    }
}
