namespace Application.Monitoring.Common;

public class BaseDto<T>
{
    public required T Id { get; set; }
};