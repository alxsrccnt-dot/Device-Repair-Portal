using AutoMapper;
using DeviceRepairPortal.Models;
using DeviceRepairPortal.Models.BillingInformation;
using DeviceRepairPortal.Models.Investigation;
using DeviceRepairPortal.Models.Job;
using Infrastructure.ApisClients.Common;
using Infrastructure.ApisClients.Management;
using Infrastructure.ApisClients.Management.Requests.Billings;
using Infrastructure.ApisClients.Management.Requests.Investigations;
using Infrastructure.ApisClients.Management.Requests.Jobs;
using Infrastructure.ApisClients.Management.Requests.Phases;
using Infrastructure.ApisClients.Monitoring;
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

        var model = mapper.Map<PaginatedViewModel<JobViewModel>>(dto);

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Details(Guid jobId)
    {
        var dto = await monitoringServicesClient
            .GetJobByIdAsync(jobId);

        var model = mapper.Map<JobViewModel>(dto);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Guid ticketId)
    {
        await managementServicesClient.CreateJobAsync(new CreateJobRequest() { TicketId = ticketId});
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> AddInvestigation(CreateInvestigationInputModel model)
    {
        var request = mapper.Map<CreateInvestigationRequest>(model);

        await managementServicesClient.CreateJobInvestigationAsync(request);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> AddBilling(CreateBillingInformationInputModel model)
    {
        var request = mapper.Map<CreateBillingInformationRequest>(model);
        await managementServicesClient.CreateJoBillingbAsync(request);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> AddRepairPhase(Guid jobId)
    {
        await managementServicesClient.CreateJobPhaseAsync(new CreatePhaseRequest(jobId, State.Repair));

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> AddReturnPhase(Guid jobId)
    {
        await managementServicesClient.CreateJobPhaseAsync(new CreatePhaseRequest(jobId, State.Return));

        return RedirectToAction(nameof(Index));
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddComment(CreateBillingInformationInputModel model)
    {
        // call API / service
        // model.JobId
        // model.Amount
        // model.DiscountId

        return RedirectToAction(nameof(Index));
    }
}