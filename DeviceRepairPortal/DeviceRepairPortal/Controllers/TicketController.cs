using Infrastructure.ApisClients.Monitoring;
using Infrastructure.ApisClients.Monitoring.Requests.Common;
using Microsoft.AspNetCore.Mvc;

namespace DeviceRepairPortal.Controllers;

public class TicketController(IMonitoringServicesClient monitoringServicesClient) : Controller
{
    public IActionResult Index()
        => View();

    [HttpPost]
    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
    {
        if (ModelState.IsValid)
        {
            var token = await monitoringServicesClient.GetUserTicketsAsync(
                new PaginatedRequest(pageNumber, pageSize));
        }

        return RedirectToAction("Home", "Index");
    }
}