using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class UserDetailsProfileConfiguration : IEntityTypeConfiguration<UserDetails>
{
	public void Configure(EntityTypeBuilder<UserDetails> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Street)
			.HasMaxLength(254);

		builder.Property(x => x.City)
			.HasMaxLength(128);

		builder.Property(x => x.State)
			.HasMaxLength(128);

		builder.Property(x => x.Country)
			.HasMaxLength(128);

		builder.HasOne(x => x.User)
			   .WithOne(x => x.UserDetails)
			   .HasForeignKey<UserDetails>(x => x.UserId)
			   .OnDelete(DeleteBehavior.Restrict);
	}
}