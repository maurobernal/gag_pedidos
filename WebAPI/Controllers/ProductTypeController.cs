using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Interface;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductTypeController : Controller
{
    private IProductTypeService _productTypeService;

    public ProductTypeController(IProductTypeService productTypeService)
    {
        _productTypeService = productTypeService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] ProductTypeDTO productType)
    {
        var res = _productTypeService.AddProductType(productType);
        return Ok(res);
    }

    [HttpPut("{id}")]
    public IActionResult Update(ProductTypeDTO productType, int id)
    {
        if (id != productType.id) return BadRequest();
        var res = _productTypeService.UpdateProductType(productType);
        return Ok(res);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var res = _productTypeService.DeleteProductType(id);
        return Ok(res);
    }

    [HttpGet("{id}")]
    public IActionResult ListOne(int id)
    {
        var res = _productTypeService.SelectProductType(id);
        if (res == null) return NotFound();

        return Ok(res);
    }

    [HttpGet("List")]
    public IActionResult ListAll(string option="T")
    {
        var res = _productTypeService.SelectListProductType(option);
        return Ok(res);
    }
}
