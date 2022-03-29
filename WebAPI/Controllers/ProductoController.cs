using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;
using WebAPI.DTOs;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : Controller
{
    private IProductoService _productoService;

    public ProductoController(IProductoService productoService)
    {
        _productoService = productoService;
    }
    [HttpPost]
    public IActionResult Create([FromBody] ProductoDTO producto)
    {
        var res = _productoService.AddProducto(producto);
        return Ok(res);
    }

    [HttpPut("{id}")]
    public IActionResult Update(ProductoDTO producto, int id)
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
        return Ok(res);
    }

    [HttpGet("Listar")]
    public IActionResult ListAll()
    {
        var res = _productoService.SelectListProducto();
        return Ok(res);
    }
}