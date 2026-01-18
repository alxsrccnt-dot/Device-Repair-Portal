using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class CommentProfileConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(x => x.CreatedBy)
               .HasMaxLength(50)
               .IsRequired();
        builder.Property(x => x.UsernameOfCreatedBy)
               .HasMaxLength(50)
               .IsRequired();
        builder.Property(x => x.CreateAt)
               .IsRequired();

        builder.Property(c => c.Content)
               .IsRequired()
               .HasMaxLength(1000);

        builder.HasOne(c => c.Job)
               .WithMany(j => j.Comments)
               .HasForeignKey(c => c.JobId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}