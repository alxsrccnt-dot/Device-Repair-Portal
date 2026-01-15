using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class InvestigationProfileConfiguration : IEntityTypeConfiguration<Investigation>
{
    public void Configure(EntityTypeBuilder<Investigation> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(x => x.CreatedBy)
               .HasMaxLength(50)
               .IsRequired();
        builder.Property(x => x.UsernameOfCreatedBy)
               .HasMaxLength(50)
               .IsRequired();
        builder.Property(x => x.CreateAt)
               .IsRequired();

        builder.Property(i => i.Conclusion)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(i => i.Description)
               .IsRequired()
               .HasMaxLength(1000);

        builder.HasOne(j => j.Job)
               .WithOne(j => j.Investigation)
               .HasForeignKey<Investigation>(i => i.JobId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(i => i.Issues)
               .WithMany(inv => inv.Investigations)
               .UsingEntity(j => j.ToTable("InvestigationIssues"));
    }
}