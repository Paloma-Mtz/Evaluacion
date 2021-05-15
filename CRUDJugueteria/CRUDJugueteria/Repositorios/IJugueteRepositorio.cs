using CRUDJugueteria.Data;
using CRUDJugueteria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDJugueteria.Repositorios
{
    public interface IJugueteRepositorio : IRepositorio<Juguete>
    {
    }

    public class JugueteRepositorio: Repositorio<Juguete>, IJugueteRepositorio
    {
        public JugueteRepositorio(AppDbContext dbContext): base(dbContext)
        {

        }
    }
}
