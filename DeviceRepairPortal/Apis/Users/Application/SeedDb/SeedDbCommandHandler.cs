using Application.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.SeedDb;

public class SeedDbCommandHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : IRequestHandler<SeedDbCommand>
{
    public async Task Handle(SeedDbCommand command, CancellationToken cancellationToken)
    {
        string[] roles =
        {
            AppRoles.Admin.ToString(),
            AppRoles.Technician.ToString(),
            AppRoles.User.ToString()
        };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        var password = "Test!234";

        var admin = new User
        {
            UserName = "Admin",
            Email = "admin@admin.com",
            IsActive = true
        };
        var result1 = await userManager.CreateAsync(admin, password);
        await userManager.AddToRoleAsync(admin, AppRoles.Admin);

        var tehnician = new User
        {
            UserName = "Tehnician",
            Email = "tehnician@tehnician.com",
            IsActive = true
        };
        var result2 = await userManager.CreateAsync(tehnician, password);
        await userManager.AddToRoleAsync(tehnician, AppRoles.Technician);

        var user = new User
        {
            UserName = "User",
            Email = "user@user.com",
            IsActive = true
        };
        var result3 = await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, AppRoles.User);
    }
}
