using AutoMapper;
using DeviceRepairPortal.Models.Device;
using DeviceRepairPortal.Models.Issue;
using DeviceRepairPortal.Models.Ticket;
using Infrastructure.ApisClients.Monitoring.Dtos;

namespace DeviceRepairPortal.Mapper;

public class ApiToVmProfile : Profile
{
    public ApiToVmProfile()
    {
        CreateMap<PaginatedResultDto<TicketDto>, PaginatedResultModel<TicketModel>>();
        CreateMap<TicketDto, TicketModel>();
        CreateMap<DeviceDto, DeviceModel>();
        CreateMap<IssueDto, IssueModel>();
    }
}