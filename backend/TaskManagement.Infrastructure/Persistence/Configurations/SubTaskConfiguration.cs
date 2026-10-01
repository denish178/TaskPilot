using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Persistence.Configurations;

public class SubTaskConfiguration : IEntityTypeConfiguration<SubTask>
{
    public void Configure(EntityTypeBuilder<SubTask> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(s => s.IsCompleted)
            .IsRequired();

        builder.Property(s => s.TaskItemId)
            .IsRequired();

        builder.Property(s => s.CreatedAt)
            .IsRequired();

        builder.HasOne(s => s.TaskItem)
            .WithMany(t => t.SubTasks)
            .HasForeignKey(s => s.TaskItemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
