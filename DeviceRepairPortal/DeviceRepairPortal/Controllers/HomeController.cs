using DeviceRepairPortal.Models;
using DeviceRepairPortal.Models.Home;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeviceRepairPortal.Controllers;

[AllowAnonymous]
public class HomeController(IIssueCatalog issueCatalog) : Controller
{
    public async Task<IActionResult> Index()
    {
        var vm = new HomePageViewModel
        {
            Issues = await issueCatalog.GetAllAsync()
        };

        return View(vm);
    }

    public IActionResult Privacy()
        => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
        => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}