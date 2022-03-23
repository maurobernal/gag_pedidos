using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OriginController : Controller  
{
    private OriginService _originService;

    public OriginController()
    {
        _originService = new();
    }
    [HttpPost]
    public IActionResult Create([FromBody] Origin origin)
    {
        var res = _originService.AddOrigin(origin);
        return Ok(res);
    }

    [HttpPut("id")]
    public IActionResult Update(Origin origin, int id)
    {
        if (id != origin.id) return BadRequest();
        var res = _originService.UpdateOrigin(origin);
        return Ok(res);
    }

    [HttpDelete("id")]
    public IActionResult Delete(int id)
    {
        var res = _originService.DeleteOrigin(id);
        return Ok(res);
    }

    [HttpGet("id")]
    public IActionResult ListOne(int id)
    {
        var res = _originService.SelectOrigin(id);
        if (res == null) return NotFound();
        return Ok(res);
    }

    [HttpGet("List")]
    public IActionResult ListAll()
    {
        var res = _originService.SelectListOrigin();
        return Ok(res);
    }
}

