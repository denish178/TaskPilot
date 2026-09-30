namespace TaskManagement.Domain.Entities;

public class TeamMember
{
    public int TeamId { get; set; }

    public Team Team { get; set; } = null!;

    public int UserId { get; set; }

    public User User { get; set; } = null!;

    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
}