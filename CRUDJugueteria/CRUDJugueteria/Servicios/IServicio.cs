using CRUDJugueteria.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDJugueteria.Servicios
{
    public interface IServicio<TEntity> where TEntity : class
    {
        Task Agrega(TEntity entidad);

        Task<List<TEntity>> ObtenerTodo();

        Task<TEntity> ObtenerPorId(int id);

        Task<TEntity> Actualiza(TEntity entidad);

        Task Elimina(int id);

    }

    public class Servicio<TEntity> : IServicio<TEntity> where TEntity : class
    {
        private IRepositorio<TEntity> _repositorio { get; set; }

        public Servicio(IRepositorio<TEntity> repositorio)
        {
            _repositorio = repositorio;
        }
        public async Task<TEntity> Actualiza(TEntity entidad)
        {
            return await _repositorio.Actualiza(entidad);
        }

        public async Task Agrega(TEntity entidad)
        {
            await _repositorio.Agrega(entidad);

        }

        public async Task Elimina(int id)
        {
            await _repositorio.Elimina(id);
        }

        public async Task<TEntity> ObtenerPorId(int id)
        {
            return await _repositorio.ObtenerPorId(id);
        }

        public async Task<List<TEntity>> ObtenerTodo()
        {
            return await _repositorio.ObtenerTodo();
        }
    }
}
