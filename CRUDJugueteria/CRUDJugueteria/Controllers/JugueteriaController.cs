using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDJugueteria.Data;
using CRUDJugueteria.Models;
using CRUDJugueteria.Servicios;

namespace CRUDJugueteria.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class JugueteriaController : ControllerBase
    {
        private readonly IJugueteServicio _servicio;

        public JugueteriaController(IJugueteServicio servicio)
        {
            _servicio = servicio;
        }

        // GET: Jugueteria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Juguete>>> Index()
        {
            return await _servicio.ObtenerTodo();
        }

        //// GET: Jugueteria/Details/5
        //public async Task<ActionResult<Juguete>> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var juguete = await _servicio.ObtenerPorId(id.Value);
        //    return juguete;
        //}


        // POST: Jugueteria/Create 
        [HttpPost]
        public async Task<ActionResult<Juguete>> Create([Bind("Id,Nombre,Descripcion,RestriccionEdad,Compañia,Precio")] Juguete juguete)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    await _servicio.Agrega(juguete);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return juguete;
        }

        // PUT: Jugueteria/Edit/5 
        [HttpPut("{id}")]
        public async Task<ActionResult<Juguete>> Edit(int id, [Bind("Id,Nombre,Descripcion,RestriccionEdad,Compañia,Precio")] Juguete juguete)
        {
            if (id != juguete.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                juguete = await _servicio.Actualiza(juguete);
            }
            return juguete;
        }


        // Delete: Jugueteria/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _servicio.Elimina(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
