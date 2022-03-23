using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrigenController : Controller
    {
        private OrigenService _origenService;
        private ProveedoresService _proveedoresService;
        public OrigenController()
        {
            _origenService = new();
            _proveedoresService = new();
        }


        [HttpPost()]
        public IActionResult Crear([FromBody] Origen origen)
        {
            var res = _origenService.AddOrigen(origen);
            return Ok(res);
        }
        
        [HttpPut("{id}")]
        public IActionResult Actualizar([FromBody] Origen origen, int id)
        {
            if (id != origen.Id) return  BadRequest();
            var res = _origenService.UpdateOrigen(origen);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var res = _origenService.DeleteOrigen(id);
            return Ok(res);
        }



        [HttpGet("Listar")]
        public IActionResult ListarAll()
        {
            var res = _origenService.SelectListOrigen();
            return Ok(res);

        }
            [HttpGet("Proveedores")]
            public IActionResult ListarProveedresAll()
            {
                var res = _proveedoresService.GetProveedores();
                return Ok(res);
            }

            [HttpGet("{id}")]
        public IActionResult Listar(int id)
        {
            var res = _origenService.SelectOrigen(id);
            if(res == null) return NotFound();
            return Ok(res);
        }

        
    }
}
