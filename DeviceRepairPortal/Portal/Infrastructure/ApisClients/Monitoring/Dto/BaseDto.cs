namespace Infrastructure.ApisClients.Monitoring.Dto;

public record BaseDto<T>
{
    public T Id { get; set; }
};