using ApartShare.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApartShare.Infrastructure.Persistence.Configurations;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired();

        builder.HasIndex(t => t.Email)
            .IsUnique();

        builder.Property(t => t.UserName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(t => t.Password)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(t => t.ImageBase64ByteArray)
            .HasColumnName("Blob")
            .IsRequired();

        builder.HasOne(t => t.Apartment)
            .WithOne(a => a.Owner)
            .HasForeignKey<User>(t => t.ApartmentId);
    }
}
