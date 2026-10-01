using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Persistence.Configurations;

public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property(f => f.TaskItemId)
            .IsRequired();

        builder.Property(f => f.Comment)
            .HasMaxLength(2000);

        builder.Property(f => f.CreatedAt)
            .IsRequired();

        builder.HasIndex(f => new { f.TaskItemId, f.FromUserId })
            .IsUnique();

        builder.HasOne(f => f.TaskItem)
            .WithMany(t => t.Feedback)
            .HasForeignKey(f => f.TaskItemId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(f => f.FromUser)
            .WithMany()
            .HasForeignKey(f => f.FromUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(f => f.ToUser)
            .WithMany()
            .HasForeignKey(f => f.ToUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
