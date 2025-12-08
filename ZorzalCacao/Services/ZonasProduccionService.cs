using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ZorzalCacao.Data;
using ZorzalCacao.Models;

namespace ZorzalCacao.Services;

public class ZonasProduccionService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Guardar (ZonasProduccion zona)
    {
        if (!await Existe (zona.ZonaId))
        {
            return await Insertar(zona);
        }
        else
        {
            return await Modificar(zona);
        }
    }

    private async Task<bool> Existe (int zonaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.ZonasProduccion.AnyAsync(z => z.ZonaId == zonaId);
    }

    private async Task<bool> Insertar (ZonasProduccion zona)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.ZonasProduccion.Add(zona);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar (ZonasProduccion zona)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(zona);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<ZonasProduccion?> Buscar(int zonaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.ZonasProduccion
            .Include(p => p.Productor)
            .FirstOrDefaultAsync(z => z.ZonaId == zonaId);
    }

    public async Task<bool> Eliminar (int zonaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.ZonasProduccion
            .AsNoTracking()
            .Where(z => z.ZonaId == zonaId)
            .ExecuteDeleteAsync() > 0;
    }
    public async Task<List<ZonasProduccion>> Listar (Expression<Func<ZonasProduccion, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.ZonasProduccion
            .Include(p => p.Productor)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}
