using Microsoft.AspNetCore.Identity;
using ZorzalCacao.Data;

namespace ZorzalCacao.Services;

public interface IUserRoleService
{
    Task<List<ApplicationUser>> GetUsersByRoleAsync(string roleName);
    Task<List<ApplicationUser>> GetProductoresAsync();
    Task<List<ApplicationUser>> GetEmpleadosAsync();
    Task<ApplicationUser?> GetUserByIdAsync(string userId);
}

public class UserRoleService : IUserRoleService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserRoleService(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<List<ApplicationUser>> GetUsersByRoleAsync(string roleName)
    {
        var role = await _roleManager.FindByNameAsync(roleName);
        if (role == null)
            return new List<ApplicationUser>();

        var usersInRole = await _userManager.GetUsersInRoleAsync(roleName);
        return usersInRole.ToList();
    }

    public async Task<List<ApplicationUser>> GetProductoresAsync()
    {
        return await GetUsersByRoleAsync("Productor");
    }

    public async Task<List<ApplicationUser>> GetEmpleadosAsync()
    {
        return await GetUsersByRoleAsync("Empleado");
    }
    public async Task<ApplicationUser?> GetUserByIdAsync(string userId)
    {
        return await _userManager.FindByIdAsync(userId);
    }

}

