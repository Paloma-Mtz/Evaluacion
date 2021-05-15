using CRUDJugueteria.Data;
using CRUDJugueteria.Models;
using CRUDJugueteria.Repositorios;
using CRUDJugueteria.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDJugueteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JuguetesController : ControllerBase
    {
        private readonly IJugueteServicio _servicio;
         

        public JuguetesController(IJugueteServicio jugueteServicio)
        {
            _servicio = jugueteServicio;
        }

        [HttpGet]
        public async Task<IEnumerable<Juguete>> Get()
        {
           var lista = await _servicio.ObtenerTodo();

            return lista.AsEnumerable();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizaTarjeta(int id, Juguete juguete)
        {

            await _servicio.Actualiza(juguete);

            return null;
        }

    }
}
