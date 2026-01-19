using Domain.Entities.Base;

namespace Domain.Entities;

public class Issue(string devicePiece, string description, decimal price) : BaseEntity<int>
{
    public string DevicePiece { get; set; } = devicePiece;
    public string Description { get; set; } = description;
    public decimal Price { get; set; } = price;

    public ICollection<Ticket> Tickets { get; set; } = [];
    public ICollection<Investigation> Investigations { get; set; } = [];
}