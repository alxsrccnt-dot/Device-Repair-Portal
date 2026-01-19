using AutoMapper;
using DeviceRepairPortal.Models.Ticket;
using Infrastructure.ApisClients.Management.Requests.Tickets;

namespace DeviceRepairPortal.Mapper;

public class ViewModelToRequestProfile : Profile
{
    public ViewModelToRequestProfile()
    {
        CreateMap<CreateTicketViewModel, CreateTicketRequest>()
            .ForMember(d => d.IssuesIds, opt => opt.MapFrom(src => src.SelectedIssueIds))
            .ForMember(d => d.Model, opt => opt.MapFrom(src => src.DeviceModel));
    }
}
