using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class JobProfileConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.HasKey(j => j.Id);

        builder.HasIndex(j => j.CreatedBy);
        builder.Property(x => x.CreatedBy)
               .HasMaxLength(50)
               .IsRequired();
        builder.Property(x => x.UsernameOfCreatedBy)
               .HasMaxLength(50)
               .IsRequired();
        builder.Property(x => x.CreateAt)
               .IsRequired();

        builder.HasOne(t => t.Ticket)
               .WithOne(d => d.Job)
               .HasForeignKey<Job>(t => t.TicketId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}