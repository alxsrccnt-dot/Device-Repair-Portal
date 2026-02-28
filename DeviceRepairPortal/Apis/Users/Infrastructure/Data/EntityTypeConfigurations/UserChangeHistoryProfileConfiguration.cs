using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class UserChangeHistoryProfileConfiguration : IEntityTypeConfiguration<UserChangeHistory>
{
    public void Configure(EntityTypeBuilder<UserChangeHistory> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ChangedFieldOldValue)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.ChangedFieldName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.ChangedAt)
            .IsRequired();

        builder.Property(x => x.UserId)
            .HasMaxLength(38);

        builder.HasOne(x => x.User)
            .WithMany(x => x.UserChangeHistories)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}