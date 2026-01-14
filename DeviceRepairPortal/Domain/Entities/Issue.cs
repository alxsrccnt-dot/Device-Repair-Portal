using Domain.Entities.Base;

namespace Domain.Entities;

public class Issue : Entity<int>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }

    public ICollection<Ticket> Tickets { get; set; } = [];
    public ICollection<Investigation> Investigations { get; set; } = [];
}