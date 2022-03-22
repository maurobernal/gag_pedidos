using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : Controller
{
    private ProductoService _productoService;

    public ProductoController()
    {
        _productoService = new();
    }
    [HttpPost]
    public IActionResult Create([FromBody] Producto producto)
    {
        var res = _productoService.AddProducto(producto);
        return Ok(res);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Producto producto, int id)
    {
        if (id != producto.Id) return BadRequest();
        var res = _productoService.UpdateProducto(producto);
        return Ok(res);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var res = _productoService.DeleteProducto(id);
        return Ok(res);
    }

    [HttpGet("{id}")]
    public IActionResult ListOne(int id)
    {
        var res = _productoService.SelectProducto(id);
        return Ok();
    }

    [HttpGet("Listar")]
    public IActionResult ListAll()
    {
        var res = _productoService.SelectListProducto();
        return Ok(res);
    }
}