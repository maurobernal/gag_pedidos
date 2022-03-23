using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : Controller
{
    private ProductService _productService;

    public ProductController()
    {
        _productService = new();
    }

    [HttpPost]
    public IActionResult Create([FromBody] Product product)
    {
        var res = _productService.AddProduct(product);
        return Ok(res);
    }

    [HttpPut("id")]
    public IActionResult Update(Product product, int id)
    {
        if (id != product.id) return BadRequest();
        var res = _productService.UpdateProduct(product);
        return Ok(res);
    }

    [HttpDelete("id")]
    public IActionResult Delete(int id)
    {
        var res = _productService.DeleteProduct(id);
        return Ok(res);
    }

    [HttpGet("id")]
    public IActionResult ListOne(int id)
    {
        var res = _productService.SelectProduct(id);
        if (res == null) return NotFound();

        return Ok(res);
    }

    [HttpGet("List")]
    public IActionResult ListAll()
    {
        var res = _productService.SelectListProduct();
        return Ok(res);
    }
}
