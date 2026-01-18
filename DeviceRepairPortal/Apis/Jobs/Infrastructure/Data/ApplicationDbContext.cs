using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

internal class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    internal DbSet<Device> Devices { get; set; }
    internal DbSet<Ticket> Tickets { get; set; }
    internal DbSet<Job> Jobs { get; set; }
    internal DbSet<BillingInformation> BillingInformations { get; set; }
    internal DbSet<Discount> Discounts { get; set; }
    internal DbSet<Comment> Comments { get; set; }
	internal DbSet<Investigation> Investigations { get; set; }
	internal DbSet<Issue> Issues { get; set; }
	internal DbSet<Phase> Phases { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		base.OnModelCreating(modelBuilder);
	}
}