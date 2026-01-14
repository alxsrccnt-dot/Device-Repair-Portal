using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class PhaseProfileConfiguration : IEntityTypeConfiguration<Phase>
{
    public void Configure(EntityTypeBuilder<Phase> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(x => x.CreatedBy)
               .HasMaxLength(50)
               .IsRequired();
        builder.Property(x => x.CreateAt)
               .IsRequired();

        builder.Property(p => p.State)
               .IsRequired();

        builder.HasOne(p => p.Job)
               .WithMany(j => j.Phases)
               .HasForeignKey(p => p.JobId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}