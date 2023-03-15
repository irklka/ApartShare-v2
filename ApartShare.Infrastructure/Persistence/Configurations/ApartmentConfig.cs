using ApartShare.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApartShare.Infrastructure.Persistence.Configurations;

public class ApartmentConfig : IEntityTypeConfiguration<Apartment>
{
    public void Configure(EntityTypeBuilder<Apartment> builder)
    {
        builder.ToTable("Apartments");

        builder.HasKey(t => t.Id);
        
        builder.Property(t => t.City)
            .HasColumnName("City")
            .IsRequired();
        
        builder.Property(t => t.Address)
            .HasColumnName("Address")
            .IsRequired();
        
        builder.Property(t => t.BedsNumber)
            .HasColumnName("NumberOfBeds")
            .IsRequired();
        
        builder.Property(t => t.ImageBase64ByteArray)
            .HasColumnName("Blob")
            .IsRequired();
        
        builder.Property(t => t.DistanceToCenter)
            .HasColumnName("DistanceToCenter")
            .IsRequired();
        
        builder.HasOne(t => t.Owner)
            .WithOne(u => u.Apartment)
            .HasForeignKey<Apartment>(u => u.OwnerId)
            .IsRequired();
    }
}
