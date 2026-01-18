using AutoMapper;
using DeviceRepairPortal.Models.BillingInformation;
using DeviceRepairPortal.Models.Investigation;
using DeviceRepairPortal.Models.Job;
using Infrastructure.ApisClients.Management;
using Infrastructure.ApisClients.Management.Requests.Jobs;
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
        await managementServicesClient.CreateJobAsync(new CreateJobRequest() { TicketId = ticketId});
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> AddInvestigation(CreateInvestigationInputModel model)
    {
        // call API / service here
        // model.JobId
        // model.Conclusion
        // model.Description
        // model.IssueIds

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> AddBilling(CreateBillingInformationInputModel model)
    {
        // call API / service
        // model.JobId
        // model.Amount
        // model.DiscountId

        return RedirectToAction(nameof(Index));
    }
}