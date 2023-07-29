using Microsoft.AspNetCore.Mvc;
using test_api2.Models;
using System.Collections.Generic;

namespace test_api2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiciosController : ControllerBase
    {
        [HttpGet]
        public List<ServicioModel> ObtenerServicios()
        {
            var serviciosService = new ServicioService();
            return serviciosService.LeerServicio();
        }

        [HttpGet("{id:int}")]
        public ServicioModel ObtenerServicio(int id)
        {
            var serviciosService = new ServicioService();
            return serviciosService.BuscarServicio(id);
        }

        [HttpPost]
        public IActionResult AgregarServicio([FromBody] ServicioModel servicio)
        {
            var serviciosService = new ServicioService();
            var res = serviciosService.GuardarServicio(servicio);

            if (res)
                return Ok("Guardado con éxito");
            else
                return Ok("Error al guardar");
        }

        [HttpDelete("{id:int}")]
        public IActionResult ElimicarServicio(int id)
        {
            var serviciosService = new ServicioService();
            var res = serviciosService.EliminarServicio(id);

            if (res)
                return Ok("Eliminado con éxito");
            else
                return Ok("Error al eliminar");
        }

        [HttpPut("{id:int}")]
        public IActionResult EditarServicio(int id, [FromBody] ServicioModel servicio)
        {
            var serviciosService = new ServicioService();
            var res = serviciosService.EditarServicio(id, servicio);

            if (res)
                return Ok("Editado con éxito");
            else
                return Ok("Error al editar");
        }
    }
}