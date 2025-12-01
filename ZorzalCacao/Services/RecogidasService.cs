using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ZorzalCacao.Data;
using ZorzalCacao.Models;

namespace ZorzalCacao.Services
{
    public class RecogidasService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        public async Task<bool> Guardar(Recogidas recogida)
        {
            if (!await Existe(recogida.RecogidaId))
            {
                return await Insertar(recogida);
            }
            else
            {
                return await Modificar(recogida);
            }
        }

        public async Task<bool> Existe(int recogidaId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Recogidas.AnyAsync(r => r.RecogidaId == recogidaId);
        }

        public async Task<bool> Insertar(Recogidas recogida)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Recogidas.Add(recogida);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Recogidas recogida)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(recogida);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<Recogidas?> Buscar(int recogidaId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Recogidas
                .Include(r => r.Productor)
                .FirstOrDefaultAsync(r => r.RecogidaId == recogidaId);
        }

        public async Task<bool> Eliminar(int recogidaId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Recogidas
                .AsNoTracking()
                .Where(r => r.RecogidaId == recogidaId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<List<Recogidas>> Listar(Expression<Func<Recogidas, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Recogidas
                .Include(r => r.Productor)
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
