using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Entities;

public class StatusChangeRequest
{
    public int Id { get; set; }

    public int TaskItemId { get; set; }

    public TaskItem TaskItem { get; set; } = null!;

    public int RequestedById { get; set; }

    public User RequestedBy { get; set; } = null!;

    public TaskItemStatus RequestedFromStatus { get; set; }

    public TaskItemStatus RequestedStatus { get; set; }

    public StatusChangeRequestStatus Status { get; set; }
        = StatusChangeRequestStatus.Pending;

    public DateTime RequestedAt { get; set; } = DateTime.UtcNow;

    public DateTime? ReviewedAt { get; set; }

    public int? ReviewedById { get; set; }

    public User? ReviewedBy { get; set; }
}