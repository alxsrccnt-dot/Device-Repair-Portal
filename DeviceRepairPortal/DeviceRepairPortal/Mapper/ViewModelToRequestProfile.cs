using AutoMapper;
using DeviceRepairPortal.Models.BillingInformation;
using DeviceRepairPortal.Models.Investigation;
using DeviceRepairPortal.Models.Ticket;
using Infrastructure.ApisClients.Management.Requests.Billings;
using Infrastructure.ApisClients.Management.Requests.Investigations;
using Infrastructure.ApisClients.Management.Requests.Tickets;

namespace DeviceRepairPortal.Mapper;

public class ViewModelToRequestProfile : Profile
{
    public ViewModelToRequestProfile()
    {
        CreateMap<CreateTicketViewModel, CreateTicketRequest>()
            .ForMember(d => d.IssuesIds, opt => opt.MapFrom(src => src.SelectedIssueIds))
            .ForMember(d => d.Model, opt => opt.MapFrom(src => src.DeviceModel));

        CreateMap<CreateInvestigationInputModel, CreateInvestigationRequest>()
            .ForMember(d => d.JobId, opt => opt.MapFrom(src => src.JobId))
            .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(d => d.Conclusion, opt => opt.MapFrom(src => src.Conclusion))
            .ForMember(d => d.IssuesIds, opt => opt.MapFrom(src => src.IssueIds));

        CreateMap<CreateBillingInformationInputModel, CreateBillingInformationRequest>();

    }
}
