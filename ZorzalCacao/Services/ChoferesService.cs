using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ZorzalCacao.Data;
using ZorzalCacao.Models;

namespace ZorzalCacao.Services
{
    public class ChoferesService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        public async Task<bool> Guardar(Choferes chofer)
        {
            if (!await Existe(chofer.ChoferId))
                return await Insertar(chofer);
            else
                return await Modificar(chofer);
        }

        private async Task<bool> Existe(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Choferes.AnyAsync(c => c.ChoferId == id);
        }

        private async Task<bool> Insertar(Choferes chofer)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Choferes.Add(chofer);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Choferes chofer)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(chofer);
            return await contexto.SaveChangesAsync() > 0;
        }

        // ✅ BUSCAR CON VEHÍCULOS
        public async Task<Choferes?> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Choferes
                .Include(c => c.Vehiculos)
                .FirstOrDefaultAsync(c => c.ChoferId == id);
        }

        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            var tieneVehiculos = await contexto.Vehiculos.AnyAsync(v => v.ChoferId == id);
            if (tieneVehiculos)
                throw new Exception("No se puede eliminar el chofer porque tiene vehículos asignados.");

            return await contexto.Choferes
                .Where(c => c.ChoferId == id)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<List<Choferes>> Listar(Expression<Func<Choferes, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Choferes
                .Include(c => c.Vehiculos) // ✅ INCLUYE VEHÍCULOS
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}


