using ApartShare.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApartShare.Infrastructure.Persistence.Configurations;

public class RequestConfig : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.ToTable("Requests");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Status)
            .IsRequired();
        
        builder.Property(t => t.City)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(t => t.FromDate)
            .IsRequired();
        
        builder.Property(t => t.DueDate)
            .IsRequired();
        
        builder.HasOne(t => t.Host)
            .WithMany(t => t.HostRequests)
            .HasForeignKey(t => t.HostId)
            .IsRequired();
        
        builder.HasOne(t => t.Guest)
            .WithMany(t => t.GuestRequests)
            .HasForeignKey(t => t.GuestId)
            .IsRequired();
    }
}
