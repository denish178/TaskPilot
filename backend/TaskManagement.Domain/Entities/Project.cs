namespace TaskManagement.Domain.Entities;

public class Project
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int TeamId { get; set; }

    public Team Team { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();

    public ICollection<Sprint> Sprints { get; set; } = new List<Sprint>();
}