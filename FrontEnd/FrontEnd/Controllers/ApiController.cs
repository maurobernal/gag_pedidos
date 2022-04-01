using FrontEnd.Interfaces;
using FrontEnd.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers;
public class ApiController : Controller
{
    public IOriginService _originService;
    public IProductService _productService;
    public IProductTypeService _productTypeService;

    public ApiController(IOriginService originService, IProductService productService, IProductTypeService productTypeService)
    {
        _originService = originService;
        _productService = productService;
        _productTypeService = productTypeService;
    }

    // Origin 
    public IActionResult Origin() => View("CrudOrigins");
    public async Task<IActionResult> GetOrigin(int id) => Json(await _originService.Get(id));

    public async Task<IActionResult> Grid_Read_Origin([DataSourceRequest] DataSourceRequest request, ProductModel o)
    {
        var origins = await _originService.GetAll();

        return Json(origins.ToDataSourceResult(request));
    }

    public async Task<IActionResult> Grid_Create_Origin(ProductModel o) => Json(await _originService.Add(o));
    public async Task<IActionResult> Grid_Update_Origin(ProductModel o) => Json(await _originService.Update(o));
    public async Task Grid_Delete_Origin(int id) => await _originService.Delete(id);


    // Product
    public IActionResult Products() => View("CrudProducts");
    public async Task<IActionResult> GetProduct(int id) => Json(await _productService.Get(id));

    public async Task<IActionResult> Grid_Read_Products([DataSourceRequest] DataSourceRequest request, ProductModel p)
    {
        var products = await _productService.GetAll();

        return Json(products.ToDataSourceResult(request));
    }

    public async Task<IActionResult> Grid_Create_Products( ProductModel p ) => Json(await _productService.Add(p));
    public async Task<IActionResult> Grid_Update_Products( ProductModel p ) => Json(await _productService.Update(p));
    public async Task Grid_Delete_Products( int id ) => await _productService.Delete(id);


    // Product Type
    public IActionResult ProductsType() => View("CrudProductsType");
    public async Task<IActionResult> GetProductType(int id) => Json(await _productTypeService.Get(id));

    public async Task<IActionResult> Grid_Read_ProductsType([DataSourceRequest] DataSourceRequest request, ProductTypeModel pt)
    {
        var productsType = await _productTypeService.GetAll();

        return Json(productsType.ToDataSourceResult(request));
    }

    public async Task<IActionResult> Grid_Create_ProductsType(ProductTypeModel pt) => Json(await _productTypeService.Add(pt));
    public async Task<IActionResult> Grid_Update_ProductsType(ProductTypeModel pt) => Json(await _productTypeService.Update(pt));
    public async Task Grid_Delete_ProductsType(int id) => await _productTypeService.Delete(id);


}
