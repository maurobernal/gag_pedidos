using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Interface;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : Controller
{
    private IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] ProductDTO product)
    {
        var res = _productService.AddProduct(product);
        return Ok(res);
    }

    [HttpPut("{id}")]
    public IActionResult Update(ProductDTO product, int id)
    {
        if (id != product.id) return BadRequest();
        var res = _productService.UpdateProduct(product);
        return Ok(res);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var res = _productService.DeleteProduct(id);
        return Ok(res);
    }

    [HttpGet("{id}")]
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
