using AutoMapper;
using DeviceRepairPortal.Models.Home;
using DeviceRepairPortal.Models.Issue;
using DeviceRepairPortal.Models.Ticket;
using Infrastructure.ApisClients.Management;
using Infrastructure.ApisClients.Management.Requests.Tickets;
using Infrastructure.ApisClients.Monitoring;
using Infrastructure.ApisClients.Monitoring.Dtos;
using Infrastructure.ApisClients.Monitoring.Requests;
using Infrastructure.ApisClients.Monitoring.Requests.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeviceRepairPortal.Controllers;

[Authorize]
public class TicketController(IMonitoringServicesClient monitoringServicesClient, IManagementServicesClient managementServicesClient, IMapper mapper) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(string userEmail = null, bool? isActive = null, int pageNumber = 1, int pageSize = 10)
    {
        PaginatedResultDto<TicketDto> paginatedResult;
        if (User.IsInRole("Technician") || User.IsInRole("Admin"))
            paginatedResult = await monitoringServicesClient
                .GetTicketsAsync(new GetTicketsRequest(userEmail, isActive, pageNumber, pageSize));
        else
            paginatedResult = await monitoringServicesClient
                .GetUserTicketsAsync(new PaginatedRequest(pageNumber, pageSize));

        var model = mapper.Map<PaginatedResultViewModel<TicketViewModel>>(paginatedResult);

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var issues = await monitoringServicesClient.GetIssuesAsync();

        var vm = new CreateTicketViewModel
        {
            AvailableIssues = mapper.Map<List<IssueViewModel>>(issues)
        };

        return View(vm);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(CreateTicketViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var request = mapper.Map<CreateTicketRequest>(model);
        await managementServicesClient.CreateTicketAsync(request);
        return RedirectToAction("Index");
    }
}