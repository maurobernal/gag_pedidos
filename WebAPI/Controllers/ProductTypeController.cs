using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductTypeController : Controller
{
    private ProductTypeService _productTypeService;

    public ProductTypeController()
    {
        _productTypeService = new();
    }

    [HttpPost]
    public IActionResult Create([FromBody] ProductType productType)
    {
        var res = _productTypeService.AddProductType(productType);
        return Ok(res);
    }

    [HttpPut("id")]
    public IActionResult Update(ProductType productType, int id)
    {
        if (id != productType.id) return BadRequest();
        var res = _productTypeService.UpdateProductType(productType);
        return Ok(res);
    }

    [HttpDelete("id")]
    public IActionResult Delete(int id)
    {
        var res = _productTypeService.DeleteProductType(id);
        return Ok(res);
    }

    [HttpGet("id")]
    public IActionResult ListOne(int id)
    {
        var res = _productTypeService.SelectProductType(id);
        return Ok(res);
    }

    [HttpGet("List")]
    public IActionResult ListAll()
    {
        var res = _productTypeService.SelectListProductType();
        return Ok(res);
    }
}
