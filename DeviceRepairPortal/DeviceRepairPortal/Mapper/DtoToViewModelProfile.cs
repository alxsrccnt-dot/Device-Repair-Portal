using AutoMapper;
using DeviceRepairPortal.Models;
using DeviceRepairPortal.Models.BillingInformation;
using DeviceRepairPortal.Models.Comment;
using DeviceRepairPortal.Models.Device;
using DeviceRepairPortal.Models.Discount;
using DeviceRepairPortal.Models.Investigation;
using DeviceRepairPortal.Models.Issue;
using DeviceRepairPortal.Models.Job;
using DeviceRepairPortal.Models.Phase;
using DeviceRepairPortal.Models.Ticket;
using Infrastructure.ApisClients.Monitoring.Dtos;

namespace DeviceRepairPortal.Mapper;

public class DtoToViewModelProfile : Profile
{
    public DtoToViewModelProfile()
    {
        CreateMap<PaginatedResultDto<TicketDto>, PaginatedResultViewModel<TicketViewModel>>();
        CreateMap<TicketDto, TicketViewModel>();
        CreateMap<DeviceDto, DeviceViewModel>();
        CreateMap<IssueDto, IssueViewModel>();

        CreateMap<PaginatedResultDto<JobDto>, PaginatedResultViewModel<JobViewModel>>();
        CreateMap<JobDto, JobViewModel>()
            .ForMember(d => d.EndDate, opt => opt.MapFrom(src => src.EndDate))
            .ForMember(d => d.Ticket, opt => opt.MapFrom(src => src.Ticket))
            .ForMember(d => d.Investigation, opt => opt.MapFrom(src => src.Investigation))
            .ForMember(d => d.BillingInformation, opt => opt.MapFrom(src => src.BillingInformation))
            .ForMember(d => d.Comments, opt => opt.MapFrom(src => src.Comments))
            .ForMember(d => d.Phases, opt => opt.MapFrom(src => src.Phases))
            .ForMember(d => d.CreateAt, opt => opt.MapFrom(src => src.CreateAt));
        CreateMap<JobTicketDto, JobTicketViewModel>()
            .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(d => d.Device, opt => opt.MapFrom(src => src.Device))
            .ForMember(d => d.Issues, opt => opt.MapFrom(src => src.Issues))
            .ForMember(d => d.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            .ForMember(d => d.CreateAt, opt => opt.MapFrom(src => src.CreateAt));
        CreateMap<BillingInformationDto, BillingInformationViewModel>()
            .ForMember(d => d.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            .ForMember(d => d.CreateAt, opt => opt.MapFrom(src => src.CreateAt));
        CreateMap<InvestigationDto, InvestigationViewModel>()
            .ForMember(d => d.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            .ForMember(d => d.CreateAt, opt => opt.MapFrom(src => src.CreateAt));
        CreateMap<CommentDto, CommentViewModel>()
            .ForMember(d => d.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            .ForMember(d => d.CreateAt, opt => opt.MapFrom(src => src.CreateAt));
        CreateMap<PhaseDto, PhaseViewModel>()
            .ForMember(d => d.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            .ForMember(d => d.CreateAt, opt => opt.MapFrom(src => src.CreateAt));
        CreateMap<DiscountDto, DiscountViewModel>();
    }
}