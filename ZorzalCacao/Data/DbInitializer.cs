using Microsoft.AspNetCore.Identity;

namespace ZorzalCacao.Data;

public static class DbInitializer
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        // Crear roles
        string[] roleNames = { "Productor", "Administrador", "Empleado" };
        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // Crear usuario Productor
        await CreateUserIfNotExists(userManager, "productor", "productor@example.com", "Productor123!", "Productor");

        // Crear usuario Administrador
        await CreateUserIfNotExists(userManager, "administrador", "admin@example.com", "Admin123!", "Administrador");

        // Crear usuario Empleado
        await CreateUserIfNotExists(userManager, "empleado", "empleado@example.com", "Empleado123!", "Empleado");
    }

    private static async Task CreateUserIfNotExists(UserManager<ApplicationUser> userManager,
        string username, string email, string password, string role)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null)
        {
            user = new ApplicationUser
            {
                UserName = username,
                Email = email,
                EmailConfirmed = true
            };
            await userManager.CreateAsync(user, password);
            await userManager.AddToRoleAsync(user, role);
        }
    }
}