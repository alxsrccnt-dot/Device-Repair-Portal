using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class BillingInformationProfileConfiguration : IEntityTypeConfiguration<BillingInformation>
{
    public void Configure(EntityTypeBuilder<BillingInformation> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(x => x.CreatedBy)
               .HasMaxLength(50)
               .IsRequired();
        builder.Property(x => x.CreateAt)
               .IsRequired();

        builder.Property(b => b.Amount)
               .HasPrecision(18, 2)
               .IsRequired();

        builder.HasOne(b => b.Job)
               .WithOne(j => j.BillingInformation)
               .HasForeignKey<BillingInformation>(b => b.JobId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(b => b.Discount)
               .WithOne(j => j.BillingInformation)
               .HasForeignKey<BillingInformation>(b => b.DIscountId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.NoAction);
    }
}