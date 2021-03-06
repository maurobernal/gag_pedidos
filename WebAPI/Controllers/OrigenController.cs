using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Interfaces;
using WebAPI.DTOs;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrigenController : Controller
{
    private IOrigenService _origenService;

    public OrigenController(IOrigenService origenservice)
    {
        _origenService = origenservice;

    }

    

    [HttpPost]
    public IActionResult Create([FromBody] OrigenDTO origen)
    {

        var res = _origenService.AddOrigen(origen);
        return Ok(res);
    }

    [HttpPut("{id}")]
    public IActionResult Update(OrigenDTO origen, int id)
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
        if (res == null) return NotFound("registro no existente");
        return Ok(res);
    }

    [HttpGet("Listar")]
    public IActionResult ListAll()
    {
        var res = _origenService.SelectListOrigen();
        return Ok(res);
    }
}