using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class IssueProfileConfiguration : IEntityTypeConfiguration<Issue>
{
    public void Configure(EntityTypeBuilder<Issue> builder)
    {
        builder.HasKey(i => i.Id);

        builder.HasIndex(i  => i.DevicePiece);
        builder.Property(i => i.DevicePiece)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(i => i.Description)
               .IsRequired()
               .HasMaxLength(1000);

        builder.Property(i => i.Price)
               .HasPrecision(18, 2);
    }
}