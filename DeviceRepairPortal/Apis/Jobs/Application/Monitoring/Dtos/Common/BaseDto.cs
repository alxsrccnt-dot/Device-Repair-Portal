namespace Application.Monitoring.Dtos.Common;

public class BaseDto<T>
{
    public required T Id { get; set; }
};