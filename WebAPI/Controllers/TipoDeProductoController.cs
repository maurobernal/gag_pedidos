using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TipoDeProductoController : Controller
{
    private TipoDeProductoService _tipoDeProductoService;

    public TipoDeProductoController()
    {
        _tipoDeProductoService = new();
    }
    [HttpPost]
    public IActionResult Create([FromBody] TipoDeProducto tipoDeProducto)
    {
        var res = _tipoDeProductoService.AddTipoDeProducto(tipoDeProducto);
        return Ok(res);
    }

    [HttpPut("{id}")]
    public IActionResult Update(TipoDeProducto tipoDeProducto, int id)
    {
        if (id != tipoDeProducto.Id) return BadRequest();
        var res = _tipoDeProductoService.UpdateTipoDeProducto(tipoDeProducto);
        return Ok(res);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var res = _tipoDeProductoService.DeleteTipoDeProducto(id);
        return Ok(res);
    }

    [HttpGet("{id}")]
    public IActionResult ListOne(int id)
    {
        var res = _tipoDeProductoService.SelectTipoDeProducto(id);
        return Ok();
    }

    [HttpGet("Listar")]
    public IActionResult ListAll()
    {
        var res = _tipoDeProductoService.SelectListTipoDeProducto();
        return Ok(res);
    }
}