using CRUDJugueteria.Data;
using CRUDJugueteria.Models;
using CRUDJugueteria.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDJugueteria.Servicios
{
    public interface IJugueteServicio : IServicio<Juguete>
    {
    }

    public class JugueteServicio : Servicio<Juguete>,IJugueteServicio
    {
        private IJugueteRepositorio _jugueteRepository;

        public JugueteServicio(IJugueteRepositorio jugueteRepositorio) : base(jugueteRepositorio)
        {
            _jugueteRepository = jugueteRepositorio;
        }
    }
}
