using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class TicketProfileConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(x => x.CreatedBy)
               .HasMaxLength(50)
               .IsRequired();
        builder.Property(x => x.UsernameOfCreatedBy)
               .HasMaxLength(50)
               .IsRequired();
        builder.Property(x => x.CreateAt)
               .IsRequired();

        builder.Property(t => t.Description)
               .IsRequired()
               .HasMaxLength(500);

        builder.HasOne(t => t.Device)
               .WithOne(d => d.Ticket)
               .HasForeignKey<Ticket>(t => t.DeviceId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.Issues)
               .WithMany(i => i.Tickets)
               .UsingEntity(j => j.ToTable("TicketIssues"));
    }
}