using CRUDJugueteria.Data;
using CRUDJugueteria.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDJugueteria.Repositorios
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        Task Agrega(TEntity entidad);

        Task<List<TEntity>> ObtenerTodo();

        Task<TEntity> ObtenerPorId(int id);

        Task<TEntity> Actualiza(TEntity entidad);

        Task Elimina(int id);

    }

    public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : class
    {
        private readonly AppDbContext _dbContext;

        public Repositorio(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TEntity> Actualiza(TEntity entidad)
        {
            _dbContext.Set<TEntity>().Update(entidad);
            await _dbContext.SaveChangesAsync();

            return entidad;
        }

        public async Task Agrega(TEntity entidad)
        {
            _dbContext.Set<TEntity>().Add(entidad);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Elimina(int id)
        {
            var entity = await ObtenerPorId(id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TEntity>> ObtenerTodo()
        {

            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> ObtenerPorId(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }
    }
}
