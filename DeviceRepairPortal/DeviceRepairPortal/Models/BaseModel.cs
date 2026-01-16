namespace DeviceRepairPortal.Models;

public record BaseModel<T>
{
    public T Id { get; set; }
}
