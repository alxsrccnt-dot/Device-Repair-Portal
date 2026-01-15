using DeviceRepairPortal.Infrastructure.ApisClients;
using DeviceRepairPortal.Models;
using DeviceRepairPortal.Models.Account;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeviceRepairPortal.Controllers;

public class AccountController(IAuthServicesClient authServicesClient) : Controller
{
    public IActionResult Login()
        => View();

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var token = await authServicesClient.GetTokenAsync(model);
            if (token is null)
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            Response.Cookies.Append("access_token", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            });
        }

        return RedirectToAction("Home", "Index");
    }

    public IActionResult Register()
        => View();

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var token = await authServicesClient.CreateAccountAndGetTokenAsync(model);
            if (token is null)
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            Response.Cookies.Append("access_token", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            });
        }

        return RedirectToAction("Home", "Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
        => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}