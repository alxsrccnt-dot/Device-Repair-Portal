using AutoMapper;
using DeviceRepairPortal.Models.Job;
using Infrastructure.ApisClients.Management;
using Infrastructure.ApisClients.Monitoring;
using Infrastructure.ApisClients.Monitoring.Dtos;
using Infrastructure.ApisClients.Monitoring.Requests.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeviceRepairPortal.Controllers;

[Authorize(Roles = "Technician")]
public class JobController(IMonitoringServicesClient monitoringServicesClient, IManagementServicesClient managementServicesClient, IMapper mapper) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
    {
        var dto = await monitoringServicesClient
            .GetTehnicianJobsAsync(new PaginatedRequest(pageNumber, pageSize));

        var model = mapper.Map<PaginatedResultViewModel<JobViewModel>>(dto);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Guid ticketId)
    {
        
        return RedirectToAction("Index");
    }
}