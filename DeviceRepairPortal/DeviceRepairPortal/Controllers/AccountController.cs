using DeviceRepairPortal.Models;
using DeviceRepairPortal.Models.Account;
using Infrastructure.ApisClients.User;
using Infrastructure.ApisClients.User.Requests.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

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
            var token = await authServicesClient.GetTokenAsync(
                new AuthenticationRequest(model.Email, model.Password));
            if (token is null)
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            Response.Cookies.Append("access_token", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            });

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Email),
                new Claim(ClaimTypes.Email, model.Email)
            };

            await HttpContext.SignInAsync(
                "Cookies",
                new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies"))
            );
        }

        return RedirectToAction("Index", "Ticket");
    }

    public IActionResult Register()
        => View();

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid && model.Password == model.ConfirmPassword)
        {
            var token = await authServicesClient.CreateAccountAndGetTokenAsync(
                new RegisterRequest(model.Username, model.Email, model.Password));
            if (token is null)
                ModelState.AddModelError(string.Empty, "Invalid register attempt");

            Response.Cookies.Append("access_token", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            });
        }

        return RedirectToAction("Index", "Ticket");
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("Cookies");
        return RedirectToAction("Index", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
        => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}