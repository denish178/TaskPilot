using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Team> Teams => Set<Team>();

    public DbSet<TeamMember> TeamMembers => Set<TeamMember>();

    public DbSet<Project> Projects => Set<Project>();

    public DbSet<TaskItem> TaskItems => Set<TaskItem>();

    public DbSet<SubTask> SubTasks => Set<SubTask>();

    public DbSet<Sprint> Sprints => Set<Sprint>();

    public DbSet<StatusChangeRequest> StatusChangeRequests => Set<StatusChangeRequest>();

    public DbSet<Attachment> Attachments => Set<Attachment>();

    public DbSet<Feedback> Feedbacks => Set<Feedback>();
}
