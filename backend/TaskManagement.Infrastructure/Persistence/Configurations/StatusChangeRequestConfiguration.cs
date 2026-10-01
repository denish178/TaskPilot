using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Persistence.Configurations;

public class StatusChangeRequestConfiguration : IEntityTypeConfiguration<StatusChangeRequest>
{
    public void Configure(EntityTypeBuilder<StatusChangeRequest> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.TaskItemId)
            .IsRequired();

        builder.Property(r => r.RequestedFromStatus)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(r => r.RequestedStatus)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(r => r.Status)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(r => r.RequestedAt)
            .IsRequired();

        builder.HasIndex(r => new { r.TaskItemId, r.Status });

        builder.HasOne(r => r.TaskItem)
            .WithMany(t => t.StatusChangeRequests)
            .HasForeignKey(r => r.TaskItemId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.RequestedBy)
            .WithMany()
            .HasForeignKey(r => r.RequestedById)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.ReviewedBy)
            .WithMany()
            .HasForeignKey(r => r.ReviewedById)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
