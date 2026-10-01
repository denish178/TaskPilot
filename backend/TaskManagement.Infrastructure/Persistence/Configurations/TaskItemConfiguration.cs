using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Persistence.Configurations;

public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(t => t.Description)
            .HasMaxLength(4000);

        builder.Property(t => t.AcceptanceCriteria)
            .HasMaxLength(4000);

        builder.Property(t => t.Priority)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(t => t.Status)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(t => t.CreatedAt)
            .IsRequired();

        builder.HasIndex(t => t.ProjectId);
        builder.HasIndex(t => t.SprintId);
        builder.HasIndex(t => t.AssigneeId);
        builder.HasIndex(t => t.Status);

        builder.HasOne(t => t.Project)
            .WithMany(p => p.Tasks)
            .HasForeignKey(t => t.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.Assignee)
            .WithMany()
            .HasForeignKey(t => t.AssigneeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.AssignedBy)
            .WithMany()
            .HasForeignKey(t => t.AssignedById)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.Sprint)
            .WithMany(s => s.Tasks)
            .HasForeignKey(t => t.SprintId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(t => t.SubTasks)
            .WithOne(s => s.TaskItem)
            .HasForeignKey(s => s.TaskItemId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.StatusChangeRequests)
            .WithOne(r => r.TaskItem)
            .HasForeignKey(r => r.TaskItemId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.Attachments)
            .WithOne(a => a.TaskItem)
            .HasForeignKey(a => a.TaskItemId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.Feedback)
            .WithOne(f => f.TaskItem)
            .HasForeignKey(f => f.TaskItemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
