using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ZorzalCacao.Data;
using ZorzalCacao.Models;

namespace ZorzalCacao.Services
{
    public class EventosClimaticosService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        public async Task<bool> Guardar(EventosClimaticos evento)
        {
            if (!await Existe(evento.EventoClimaticoId))
            {
                return await Insertar(evento);
            }
            else
            {
                return await Modificar(evento);
            }
        }

        private async Task<bool> Existe(int eventoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.EventosClimaticos
                .AnyAsync(e => e.EventoClimaticoId == eventoId);
        }

        private async Task<bool> Insertar(EventosClimaticos evento)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.EventosClimaticos.Add(evento);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(EventosClimaticos evento)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(evento);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<EventosClimaticos?> Buscar(int eventoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.EventosClimaticos
                .FirstOrDefaultAsync(e => e.EventoClimaticoId == eventoId);
        }

        public async Task<bool> Eliminar(int eventoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.EventosClimaticos
                .AsNoTracking()
                .Where(e => e.EventoClimaticoId == eventoId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<List<EventosClimaticos>> Listar(Expression<Func<EventosClimaticos, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.EventosClimaticos
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
