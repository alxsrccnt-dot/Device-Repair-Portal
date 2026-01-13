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
			.IsRequired();

		builder.Property(x => x.ChangedFieldName)
			.IsRequired();

		builder.Property(x => x.ChangetAt)
			.IsRequired();

		builder.HasOne(x => x.User)
			   .WithMany(x => x.UserChangeHistories)
			   .HasForeignKey(x => x.UserId)
			   .OnDelete(DeleteBehavior.Restrict);
	}
}