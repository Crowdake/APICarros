using Microsoft.AspNetCore.Mvc;
using test_api2.Models;
using System.Collections.Generic;

namespace test_api2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        public List<CategoriaModel> ObtenerCategoria()
        {
            var categoriaService = new CategoriaService();
            return categoriaService.LeerCategoria();
        }

        [HttpGet("{id:int}")]
        public CategoriaModel ObtenerCategoria(int id)
        {
            var categoriaService = new CategoriaService();
            return categoriaService.BuscarCategoria(id);
        }

        [HttpPost]
        public IActionResult AgregarCategoria([FromBody] CategoriaModel categoria)
        {
            var categoriaService = new CategoriaService();
            var res = categoriaService.GuardarCategoria(categoria);

            if (res)
                return Ok("Guardado con éxito");
            else
                return Ok("Error al guardar");
        }

        [HttpDelete("{id:int}")]
        public IActionResult ElimicarCategoria(int id)
        {
            var categoriaService = new CategoriaService();
            var res = categoriaService.EliminarCategoria(id);

            if (res)
                return Ok("Eliminado con éxito");
            else
                return Ok("Error al eliminar");
        }

        [HttpPut("{id:int}")]
        public IActionResult EditarCategoria(int id, [FromBody] CategoriaModel categoria)
        {
            var categoriaService = new CategoriaService();
            var res = categoriaService.EditarCategoria(id, categoria);

            if (res)
                return Ok("Editado con éxito");
            else
                return Ok("Error al editar");
        }
    }
}