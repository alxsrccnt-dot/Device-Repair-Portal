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

        CreateMap<Job, JobDto>()
            .ForMember(d => d.EndDate, opt => opt.MapFrom(src => src.EndDate))
            .ForMember(d => d.Ticket, opt => opt.MapFrom(src => src.Ticket))
            .ForMember(d => d.Investigation, opt => opt.MapFrom(src => src.Investigation))
            .ForMember(d => d.BillingInformation, opt => opt.MapFrom(src => src.BillingInformation))
            .ForMember(d => d.Comments, opt => opt.MapFrom(src => src.Comments))
            .ForMember(d => d.Phases, opt => opt.MapFrom(src => src.Phases))
            .ForMember(d => d.CreateAt, opt => opt.MapFrom(src => src.CreateAt));
        CreateMap<Ticket, JobTicketDto>()
            .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(d => d.Device, opt => opt.MapFrom(src => src.Device))
            .ForMember(d => d.Issues, opt => opt.MapFrom(src => src.Issues))
            .ForMember(d => d.CreatedBy, opt => opt.MapFrom(src => src.UsernameOfCreatedBy))
            .ForMember(d => d.CreateAt, opt => opt.MapFrom(src => src.CreateAt));
        CreateMap<BillingInformation, BillingInformationDto>()
            .ForMember(d => d.CreatedBy, opt => opt.MapFrom(src => src.UsernameOfCreatedBy))
            .ForMember(d => d.CreateAt, opt => opt.MapFrom(src => src.CreateAt));
        CreateMap<Investigation, InvestigationDto>()
            .ForMember(d => d.CreatedBy, opt => opt.MapFrom(src => src.UsernameOfCreatedBy))
            .ForMember(d => d.CreateAt, opt => opt.MapFrom(src => src.CreateAt));
        CreateMap<Comment, CommentDto>()
            .ForMember(d => d.CreatedBy, opt => opt.MapFrom(src => src.UsernameOfCreatedBy))
            .ForMember(d => d.CreateAt, opt => opt.MapFrom(src => src.CreateAt));
        CreateMap<Phase, PhaseDto>()
            .ForMember(d => d.CreatedBy, opt => opt.MapFrom(src => src.UsernameOfCreatedBy))
            .ForMember(d => d.CreateAt, opt => opt.MapFrom(src => src.CreateAt));
        CreateMap<Discount, DiscountDto>();
    }
}
