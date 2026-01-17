using AutoMapper;
using DeviceRepairPortal.Models.Ticket;
using Infrastructure.ApisClients.Monitoring;
using Infrastructure.ApisClients.Monitoring.Dtos;
using Infrastructure.ApisClients.Monitoring.Requests.Common;
using Microsoft.AspNetCore.Mvc;

namespace DeviceRepairPortal.Controllers;

public class TicketController(IMonitoringServicesClient monitoringServicesClient, IMapper mapper) : Controller
{
    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
    {
        var dto = await monitoringServicesClient
            .GetUserTicketsAsync(new PaginatedRequest(pageNumber, pageSize));

        var model = mapper.Map<PaginatedResultModel<TicketModel>>(dto);

        return View(model);
    }
}