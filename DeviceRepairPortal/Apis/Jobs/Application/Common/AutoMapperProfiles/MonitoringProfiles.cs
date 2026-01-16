using AutoMapper;
using Domain.Entities;
using Application.Monitoring.Dtos;

public class MonitoringProfiles : Profile
{
    public MonitoringProfiles()
    {
        CreateMap<Ticket, TicketDto>()
            .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(d => d.Device, opt => opt.MapFrom(src => src.Device))
            .ForMember(d => d.Issues, opt => opt.MapFrom(src => src.Issues))
            .ForMember(d => d.TehnicianUsername, opt => opt.MapFrom(src => src.Job.UsernameOfCreatedBy))
            .ForMember(d => d.JobStartedAt, opt => opt.MapFrom(src => src.Job.CreateAt))
            .ForMember(d => d.JobId, opt => opt.MapFrom(src => src.Job.Id))
            .ForMember(d => d.CreatedAt, opt => opt.MapFrom(src => src.CreateAt));

        CreateMap<Device, DeviceDto>();

        CreateMap<Issue, IssueDto>();
    }
}
