using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ZorzalCacao.Data;
using ZorzalCacao.Models;

namespace ZorzalCacao.Services
{
    public class VehiculosService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        public async Task<bool> Guardar(Vehiculo vehiculo)
        {
            if (!await Existe(vehiculo.VehiculoId))
            {
                return await Insertar(vehiculo);
            }
            else
            {
                return await Modificar(vehiculo);
            }
        }

        private async Task<bool> Existe(int vehiculoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Vehiculos.AnyAsync(v => v.VehiculoId == vehiculoId);
        }

        private async Task<bool> Insertar(Vehiculo vehiculo)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Vehiculos.Add(vehiculo);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Vehiculo vehiculo)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(vehiculo);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<Vehiculo?> Buscar(int vehiculoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Vehiculos
                .FirstOrDefaultAsync(v => v.VehiculoId == vehiculoId);
        }

        public async Task<bool> Eliminar(int vehiculoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Vehiculos
                .AsNoTracking()
                .Where(v => v.VehiculoId == vehiculoId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<List<Vehiculo>> Listar(Expression<Func<Vehiculo, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Vehiculos
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

