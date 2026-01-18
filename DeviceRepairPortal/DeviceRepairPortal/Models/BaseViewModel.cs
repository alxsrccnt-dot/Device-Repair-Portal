namespace DeviceRepairPortal.Models;

public record BaseViewModel<T>
{
    public T Id { get; init; }
}
