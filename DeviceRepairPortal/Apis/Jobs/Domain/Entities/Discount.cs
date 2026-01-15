using Domain.Entities.Base;

namespace Domain.Entities;

public class Discount : BaseEntity<int>
{
    public Discount(){ }

    public Discount(string code, int value, bool isPercentage, DateTime validUntil, string createdBy, DateTime createdAt)
        : base(createdBy, createdAt)
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