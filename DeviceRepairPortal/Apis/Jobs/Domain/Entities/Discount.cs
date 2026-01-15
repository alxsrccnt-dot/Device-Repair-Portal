using Domain.Entities.Base;

namespace Domain.Entities;

public class Discount : Entity<int>
{
    public Discount(){ }

    public Discount(string code, int value, bool isPercentage, DateTime validUntil, string createdBy, string usernameOfCreatedBy, DateTime createdAt)
        : base(createdBy, usernameOfCreatedBy, createdAt)
    {
        Code = code;
        Value = value;
        IsPercentage = isPercentage;
        ValidUntil = validUntil;
    }

    public string Code { get; set; }
    public int Value { get; set; }
    public bool IsPercentage { get; set; }
    public DateTime ValidUntil { get; set; }
    public BillingInformation BillingInformation { get; set; }
}