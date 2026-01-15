using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class DeviceProfileConfiguration : IEntityTypeConfiguration<Device>
{
    public void Configure(EntityTypeBuilder<Device> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Brand)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(d => d.Model)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(d => d.SerialNumber)
               .IsRequired()
               .HasMaxLength(200);
        builder.HasIndex(d => d.SerialNumber)
               .IsUnique();
    }
}