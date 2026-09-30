namespace TaskManagement.Domain.Entities;

public class Feedback
{
    public int Id { get; set; }

    public int TaskItemId { get; set; }

    public TaskItem TaskItem { get; set; } = null!;

    public int FromUserId { get; set; }

    public User FromUser { get; set; } = null!;

    public int ToUserId { get; set; }

    public User ToUser { get; set; } = null!;

    public string? Comment { get; set; }

    public int? Rating { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}