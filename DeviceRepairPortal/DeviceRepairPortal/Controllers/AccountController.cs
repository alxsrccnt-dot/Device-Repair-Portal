using DeviceRepairPortal.Models;
using DeviceRepairPortal.Models.Account;
using Infrastructure.ApisClients.User;
using Infrastructure.ApisClients.User.Requests.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DeviceRepairPortal.Controllers;

public class AccountController(IAuthServicesClient authServicesClient) : Controller
{
    public IActionResult Login()
        => View();

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        try
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

                await SignInWithJwtAsync(token);
                return RedirectToAction("Index", "Ticket");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return View();
        }
        catch
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return View();
        }
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
            await SignInWithJwtAsync(token);
            return RedirectToAction("Index", "Ticket");
        }

        ModelState.AddModelError(string.Empty, "Invalid register attempt");
        return View();
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

    private async Task SignInWithJwtAsync(string jwt)
    {
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(jwt);

        var identity = new ClaimsIdentity(
            token.Claims,
            "Cookies",
            ClaimTypes.Name,
            ClaimTypes.Role
        );

        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync("Cookies", principal);
    }
}