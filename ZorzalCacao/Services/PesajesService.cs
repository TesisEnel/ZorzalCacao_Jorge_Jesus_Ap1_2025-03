using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ZorzalCacao.Data;
using ZorzalCacao.Models;

namespace ZorzalCacao.Services;

public class PesajesService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Guardar(Pesajes pesaje)
    {
        if (!await Existe(pesaje.PesajeId))
        {
            return await Insertar(pesaje);
        }
        else
        {
            return await Modificar(pesaje);
        }
    }

    private async Task<bool> Existe(int pesajeId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Pesajes.AnyAsync(p => p.PesajeId == pesajeId);
    }

    private async Task AfectarPesada(ICollection<PesajesDetalles> detalle, TipoOperacion operacion)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        foreach (var item in detalle)
        {
            var unidad = await contexto.Sacos.SingleAsync(u => u.SacoId == item.SacoId);

            if (operacion == TipoOperacion.Suma)
            {
                unidad.CantidadPesada += item.Cantidad;
            }
            else
            {
                unidad.CantidadPesada -= item.Cantidad;
            }
            await contexto.SaveChangesAsync();
        }
    }

    private async Task<bool> Insertar(Pesajes pesaje)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Pesajes.Add(pesaje);
        await AfectarPesada(pesaje.PesajesDetalle, TipoOperacion.Suma);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Pesajes pesaje)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var pesajeActual = await contexto.Pesajes
            .Include(p => p.PesajesDetalle)
            .FirstOrDefaultAsync(p => p.PesajeId == pesaje.PesajeId);

        if (pesajeActual == null) return false;

        await AfectarPesada(pesajeActual.PesajesDetalle, TipoOperacion.Resta);

        contexto.PesajesDetalles.RemoveRange(pesajeActual.PesajesDetalle);

        pesajeActual.Fecha = pesaje.Fecha;

        foreach (var detalle in pesaje.PesajesDetalle)
        {
            var nuevoDetalle = new PesajesDetalles
            {
                SacoId = detalle.SacoId,
                Cantidad = detalle.Cantidad,
                Peso = detalle.Peso,
            };
            pesajeActual.PesajesDetalle.Add(nuevoDetalle);
        }
        await AfectarPesada(pesaje.PesajesDetalle, TipoOperacion.Suma);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Pesajes?> Buscar(int pesajeId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Pesajes.FirstOrDefaultAsync(p => p.PesajeId == pesajeId);
    }

    public async Task<bool> Eliminar(int pesajeId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var pesajeActual = await contexto.Pesajes
            .Include(p => p.PesajesDetalle)
            .FirstOrDefaultAsync(p => p.PesajeId == pesajeId);

        if (pesajeActual == null) return false;

        await AfectarPesada(pesajeActual.PesajesDetalle, TipoOperacion.Resta);

        contexto.PesajesDetalles.RemoveRange(pesajeActual.PesajesDetalle);
        contexto.Pesajes.Remove(pesajeActual);

        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<List<Pesajes>> Listar(Expression<Func<Pesajes, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Pesajes
            .Include(p => p.PesajesDetalle)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Sacos>> ListarUnidades(Expression<Func<Sacos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Sacos
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    private enum TipoOperacion
    {
        Suma = 1,
        Resta = 2
    }
}

