using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ZorzalCacao.Data;
using ZorzalCacao.Models;

namespace ZorzalCacao.Services;

public class ControlesCalidadService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Guardar(ControlesCalidad control)
    {
        if (!await Existe(control.ControlId))
        {
            return await Insertar(control);
        }
        else
        {
            return await Modificar(control);
        }
    }
    private async Task<bool> Existe(int controlId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Controles.AnyAsync(c => c.ControlId == controlId);
    }

    private async Task<bool> Insertar(ControlesCalidad control)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Controles.Add(control);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(ControlesCalidad control)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(control);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<ControlesCalidad?> Buscar(int controlId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Controles
            .Include(c => c.Recogida)
            .Include(p => p.Empleado)
            .FirstOrDefaultAsync(c => c.ControlId == controlId);
    }

    public async Task<bool> Eliminar(int controlId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Controles
            .AsNoTracking()
            .Where(c => c.ControlId == controlId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<ControlesCalidad>> Listar(Expression<Func<ControlesCalidad, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Controles
            .Include(c=> c.Recogida)
            .Include(c => c.Empleado)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}
