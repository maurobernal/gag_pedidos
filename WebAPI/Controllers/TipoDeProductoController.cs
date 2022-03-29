using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;
using WebAPI.DTOs;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TipoDeProductoController : Controller
{
    private ITipoDeProductoService _tipoDeProductoService;

    public TipoDeProductoController(ITipoDeProductoService tipoDeProductoService)
    {
        _tipoDeProductoService = tipoDeProductoService;
    }
    [HttpPost]
    public IActionResult Create([FromBody] TipoDeProductoDTO tipoDeProducto)
    {
        var res = _tipoDeProductoService.AddTipoDeProducto(tipoDeProducto);
        return Ok(res);
    }

    [HttpPut("{id}")]
    public IActionResult Update(TipoDeProductoDTO tipoDeProducto, int id)
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
        return Ok(res);
    }

    [HttpGet("Listar")]
    public IActionResult ListAll()
    {
        var res = _tipoDeProductoService.SelectListTipoDeProducto();
        return Ok(res);
    }
}