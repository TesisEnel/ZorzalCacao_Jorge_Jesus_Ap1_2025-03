using ZorzalCacao.Models;
using ZorzalCacao.Services;

namespace ZorzalCacao.Tests;

public class ChoferesServiceTest
{
    [Fact]
    public async Task Guardar_CuandoNoExiste_DeberiaInsertarChofer()
    {
        // Arrange
        var factory = new DbContextFactoryMock("Guardar_Insertar_DB");
        var service = new ChoferesService(factory);

        var chofer = new Choferes
        {
            ChoferId = 1,
            Nombre = "Juan",
            Apellido = "Pérez",
            Cedula = "00112345678",
            Telefono = "8095551234"
        };

        // Act
        var resultado = await service.Guardar(chofer);

        // Assert
        Assert.True(resultado);

        var choferGuardado = await service.Buscar(1);
        Assert.NotNull(choferGuardado);
        Assert.Equal("Juan", choferGuardado!.Nombre);
    }

    [Fact]
    public async Task Guardar_CuandoExiste_DeberiaModificarChofer()
    {
        // Arrange
        var factory = new DbContextFactoryMock("Guardar_Modificar_DB");
        var service = new ChoferesService(factory);

        var chofer = new Choferes
        {
            ChoferId = 1,
            Nombre = "Juan",
            Apellido = "Pérez",
            Cedula = "00112345678",
            Telefono = "8095551234"
        };

        await service.Guardar(chofer);

        chofer.Nombre = "Pedro";

        // Act
        var resultado = await service.Guardar(chofer);

        // Assert
        Assert.True(resultado);

        var modificado = await service.Buscar(1);
        Assert.Equal("Pedro", modificado!.Nombre);
    }

    [Fact]
    public async Task Eliminar_CuandoTieneVehiculos_DeberiaLanzarExcepcion()
    {
        // Arrange
        var factory = new DbContextFactoryMock("Eliminar_ConVehiculos_DB");
        var service = new ChoferesService(factory);

        await service.Guardar(new Choferes
        {
            ChoferId = 1,
            Nombre = "Carlos",
            Apellido = "Díaz",
            Cedula = "00312345678",
            Telefono = "8495551234"
        });

        // Insertamos vehículo directamente
        await using (var ctx = await factory.CreateDbContextAsync())
        {
            ctx.Vehiculos.Add(new Vehiculo
            {
                VehiculoId = 1,
                ChoferId = 1
            });
            await ctx.SaveChangesAsync();
        }

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => service.Eliminar(1));
    }
}