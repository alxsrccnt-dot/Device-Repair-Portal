using Application.Monitoring.Common;
using Application.Monitoring.Jobs.Dtos;
using AutoMapper;
using Domain.Entities;

public class JobProfiles : Profile
{
    public JobProfiles()
    {
        CreateMap<Job, JobDetailsDto>()
            .ForMember(d => d.EndDate, opt => opt.MapFrom(src => src.EndDate))
            .ForMember(d => d.Ticket, opt => opt.MapFrom(src => src.Ticket))
            .ForMember(d => d.Investigation, opt => opt.MapFrom(src => src.Investigation))
            .ForMember(d => d.BillingInformation, opt => opt.MapFrom(src => src.BillingInformation))
            .ForMember(d => d.Comments, opt => opt.MapFrom(src => src.Comments))
            .ForMember(d => d.Phases, opt => opt.MapFrom(src => src.Phases))
            .ForMember(d => d.CreateAt, opt => opt.MapFrom(src => src.CreateAt));
        CreateMap<Job, JobDto>()
            .ForMember(d => d.EndDate, opt => opt.MapFrom(src => src.EndDate))
            .ForMember(d => d.Ticket, opt => opt.MapFrom(src => src.Ticket))
            .ForMember(d => d.InvestigationConclusion, opt => opt.MapFrom(src => src.Investigation.Conclusion))
            .ForMember(d => d.BillingInformationAmount, opt => opt.MapFrom(src => src.BillingInformation.Amount))
            .ForMember(d => d.CurrentPhase, opt => opt.MapFrom(src => src.Phases.OrderByDescending(p => p.CreateAt).First().State.ToString()))
            .ForMember(d => d.CurrentPhasesStartedAt, opt => opt.MapFrom(src => src.Phases.OrderByDescending(p => p.CreateAt).First().CreateAt));
        CreateMap<Ticket, JobDetailsTicketDto>()
            .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(d => d.Device, opt => opt.MapFrom(src => src.Device))
            .ForMember(d => d.UserDeclaredIssues, opt => opt.MapFrom(src => src.Issues))
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
