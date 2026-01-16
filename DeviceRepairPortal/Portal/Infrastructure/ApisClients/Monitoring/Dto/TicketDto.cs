namespace Infrastructure.ApisClients.Monitoring.Dto;

public record TicketDto(string Description, DeviceDto Device) : BaseDto<Guid>;