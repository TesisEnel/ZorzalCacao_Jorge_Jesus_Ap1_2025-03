using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ZorzalCacao.Data;
using ZorzalCacao.Models;

namespace ZorzalCacao.Services;

public class FermentacionesService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Guardar(Fermentaciones fermentacion)
    {
        if (!await Existe(fermentacion.FermentacionId))
        {
            return await Insertar(fermentacion);
        }
        else
        {
            return await Modificar(fermentacion);
        }
    }

    private async Task<bool> Existe(int fermentacionId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Fermentaciones.AnyAsync(f => f.FermentacionId == fermentacionId);
    }

    private async Task AfectarRemovida(ICollection<FermentacionesDetalles> detalle, TipoOperacion operacion)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        foreach (var item in detalle)
        {
            var remocion = await contexto.Remociones.SingleAsync(r => r.RemocionId == item.RemocionId);

            if (operacion == TipoOperacion.Suma)
            {
                remocion.Cantidad += item.Cantidad;
            }

            else
            {
                remocion.Cantidad -= item.Cantidad;
            }

            await contexto.SaveChangesAsync();
        }
    }

    private async Task<bool> Insertar(Fermentaciones fermentacion)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Fermentaciones.Add(fermentacion);
        await AfectarRemovida(fermentacion.FermentacionesDetalle, TipoOperacion.Suma);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Fermentaciones fermentacion)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var fermentacionActual = await contexto.Fermentaciones
            .Include(d => d.FermentacionesDetalle)
            .FirstOrDefaultAsync(f => f.FermentacionId == fermentacion.FermentacionId);

        if (fermentacionActual == null) return false;

        await AfectarRemovida(fermentacionActual.FermentacionesDetalle, TipoOperacion.Resta);

        contexto.FermentacionesDetalles.RemoveRange(fermentacionActual.FermentacionesDetalle);

        fermentacionActual.RecogidaId = fermentacion.RecogidaId;
        fermentacionActual.Temperatura = fermentacion.Temperatura;
        fermentacionActual.Observaciones = fermentacion.Observaciones;
        fermentacionActual.Fecha = fermentacion.Fecha;

        foreach (var detalle in fermentacion.FermentacionesDetalle)
        {
            var nuevoDetalle = new FermentacionesDetalles
            {
                RemocionId = detalle.RemocionId,
                Cantidad = detalle.Cantidad,
                Temperatura = detalle.Temperatura,
                FechaFermentacion = detalle.FechaFermentacion,
            };

            fermentacionActual.FermentacionesDetalle.Add(nuevoDetalle);
        }
        await AfectarRemovida(fermentacion.FermentacionesDetalle, TipoOperacion.Suma);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int fermentacionId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var fermentacionActual = await contexto.Fermentaciones
            .Include(d => d.FermentacionesDetalle)
            .FirstOrDefaultAsync(f => f.FermentacionId == fermentacionId);

        if (fermentacionActual == null) return false;

        await AfectarRemovida(fermentacionActual.FermentacionesDetalle, TipoOperacion.Resta);

        contexto.FermentacionesDetalles.RemoveRange(fermentacionActual.FermentacionesDetalle);
        contexto.Fermentaciones.Remove(fermentacionActual);

        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Fermentaciones?> Buscar(int fermentacionId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Fermentaciones
            .Include(d => d.FermentacionesDetalle)
            .FirstOrDefaultAsync(f => f.FermentacionId == fermentacionId);
    }

    public async Task<List<Fermentaciones>> Listar(Expression<Func<Fermentaciones, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Fermentaciones
            .Include(d => d.FermentacionesDetalle)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Remociones>> ListarRemociones(Expression<Func<Remociones, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Remociones
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
