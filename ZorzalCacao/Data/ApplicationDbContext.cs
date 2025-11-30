using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ZorzalCacao.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Roles
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "1",
                Name = "Productor",
                NormalizedName = "PRODUCTOR",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole
            {
                Id = "2",
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole
            {
                Id = "3",
                Name = "Empleado",
                NormalizedName = "EMPLEADO",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }
        );

        // Usuarios
        var productor = new ApplicationUser
        {
            Id = "1",
            UserName = "productor",
            NormalizedUserName = "PRODUCTOR",
            Email = "productor@example.com",
            NormalizedEmail = "PRODUCTOR@EXAMPLE.COM",
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString()
        };

        var administrador = new ApplicationUser
        {
            Id = "2",
            UserName = "administrador",
            NormalizedUserName = "ADMINISTRADOR",
            Email = "admin@example.com",
            NormalizedEmail = "ADMIN@EXAMPLE.COM",
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString()
        };

        var empleado = new ApplicationUser
        {
            Id = "3",
            UserName = "empleado",
            NormalizedUserName = "EMPLEADO",
            Email = "empleado@example.com",
            NormalizedEmail = "EMPLEADO@EXAMPLE.COM",
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString()
        };

        // Password hashes (todos con password "Password123!")
        var hasher = new PasswordHasher<ApplicationUser>();
        productor.PasswordHash = hasher.HashPassword(productor, "Password123!");
        administrador.PasswordHash = hasher.HashPassword(administrador, "Password123!");
        empleado.PasswordHash = hasher.HashPassword(empleado, "Password123!");

        builder.Entity<ApplicationUser>().HasData(productor, administrador, empleado);

        // Asignacion de roles a usuarios
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { RoleId = "1", UserId = "1" }, // Productor
            new IdentityUserRole<string> { RoleId = "2", UserId = "2" }, // Administrador
            new IdentityUserRole<string> { RoleId = "3", UserId = "3" }  // Empleado
        );
    }
}
