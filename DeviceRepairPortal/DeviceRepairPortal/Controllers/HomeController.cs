using AutoMapper;
using DeviceRepairPortal.Models;
using DeviceRepairPortal.Models.Home;
using DeviceRepairPortal.Models.Issue;
using Infrastructure.ApisClients.Monitoring;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeviceRepairPortal.Controllers;

public class HomeController(IMonitoringServicesClient monitoringServicesClient, IMapper mapper) : Controller
{
    public async Task<IActionResult> Index()
    {
        var issues = await monitoringServicesClient.GetIssuesAsync();

        var vm = new HomePageViewModel
        {
            Issues = mapper.Map<IEnumerable<IssueViewModel>>(issues)
        };

        return View(vm);
    }

    public IActionResult Privacy()
        => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
        => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}