using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrigenController : Controller
{
    private OrigenService _origenService;

    public OrigenController()
    {
        _origenService = new();
    }
    [HttpPost]
    public IActionResult Create([FromBody] Origen origen)
    {
        var res = _origenService.AddOrigen(origen);
        return Ok(res);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Origen origen, int id)
    {
        if (id != origen.Id) return BadRequest();
        var res = _origenService.UpdateOrigen(origen);
        return Ok(res);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var res = _origenService.DeleteOrigen(id);
        return Ok(res);
    }

    [HttpGet("{id}")]
    public IActionResult ListOne(int id)
    {
        var res = _origenService.SelectOrigen(id);
        return Ok();
    }

    [HttpGet("Listar")]
    public IActionResult ListAll()
    {
        var res = _origenService.SelectListOrigen();
        return Ok(res);
    }
}