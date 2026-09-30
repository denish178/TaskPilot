using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Entities;

public class TaskItem
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? AcceptanceCriteria { get; set; }

    public TaskPriority Priority { get; set; } = TaskPriority.Medium;

    public TaskItemStatus Status { get; set; } = TaskItemStatus.ToDo;

    public DateTime? DueDate { get; set; }

    public int ProjectId { get; set; }

    public Project Project { get; set; } = null!;

    public int? AssigneeId { get; set; }

    public User? Assignee { get; set; }

    public int? AssignedById { get; set; }

    public User? AssignedBy { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int? SprintId { get; set; }

    public Sprint? Sprint { get; set; }

    public ICollection<SubTask> SubTasks { get; set; } = new List<SubTask>();

    public ICollection<StatusChangeRequest> StatusChangeRequests { get; set; }
    = new List<StatusChangeRequest>();

    public ICollection<Attachment> Attachments { get; set; }
    = new List<Attachment>();

    public ICollection<Feedback> Feedback { get; set; }
    = new List<Feedback>();
}