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
    public IOrderService _orderService;
    public IOrderDetailService _orderDetailService;

    public ApiController(IOriginService originService, IProductService productService, IProductTypeService productTypeService, IOrderService orderService, IOrderDetailService orderDetailService)
    {
        _originService = originService;
        _productService = productService;
        _productTypeService = productTypeService;
        _orderService = orderService;
        _orderDetailService = orderDetailService;
    }

    // Origin 
    public IActionResult Origin() => View("CrudOrigins");
    public async Task<IActionResult> GetOrigin(int id) => Json(await _originService.Get(id));

    public async Task<IActionResult> Grid_Read_Origin([DataSourceRequest] DataSourceRequest request, OriginModel o, string option)
    {
        var origins = await _originService.GetAll(option);

        return Json(origins.ToDataSourceResult(request));
    }

    public async Task<IActionResult> Grid_Create_Origin(OriginModel o) => Json(await _originService.Add(o));
    public async Task<IActionResult> Grid_Update_Origin(OriginModel o) => Json(await _originService.Update(o));
    public async Task Grid_Delete_Origin(int id) => await _originService.Delete(id);


    // Product
    public IActionResult Products() => View("CrudProducts");
    public async Task<IActionResult> GetProduct(int id) => Json(await _productService.Get(id));
    public async Task<IActionResult> GetAllProducts() => Json(await _productService.GetProductsAsync());
    public async Task<IActionResult> Grid_Read_Products([DataSourceRequest] DataSourceRequest request, ProductModel p, string option)
    {
        var products = await _productService.GetAll(option);

        return Json(products.ToDataSourceResult(request));
    }

    public async Task<IActionResult> Grid_Create_Products(ProductModel p) => Json(await _productService.Add(p));
    public async Task<IActionResult> Grid_Update_Products(ProductModel p) => Json(await _productService.Update(p));
    public async Task Grid_Delete_Products(int id) => await _productService.Delete(id);


    // Product Type
    public IActionResult ProductType() => View("CrudProductsTypes");
    public async Task<IActionResult> GetProductType(int id) => Json(await _productTypeService.Get(id));

    public async Task<IActionResult> Grid_Read_ProductType([DataSourceRequest] DataSourceRequest request, ProductTypeModel pt, string option)
    {
        var productsType = await _productTypeService.GetAll(option);

        return Json(productsType.ToDataSourceResult(request));
    }

    public async Task<IActionResult> Grid_Create_ProductType(ProductTypeModel pt) => Json(await _productTypeService.Add(pt));
    public async Task<IActionResult> Grid_Update_ProductType(ProductTypeModel pt) => Json(await _productTypeService.Update(pt));
    public async Task Grid_Delete_ProductType(int id) => await _productTypeService.Delete(id);

    // Order
    public IActionResult Order() => View("CrudOrders");
    public async Task<IActionResult> GetOrder(int id) => Json(await _orderService.Get(id));
    public async Task<IActionResult> Grid_Read_Order([DataSourceRequest] DataSourceRequest request, OrderModel o, int option)
    {
        var order = await _orderService.GetAll(option);

        return Json(order.ToDataSourceResult(request));
    }
    public async Task<IActionResult> Grid_Create_Order()
    {
        OrderModel order = new OrderModel { OriginId = 1 };

        var or = await _orderService.Add(order);

        return RedirectToAction("OrderDetail", new { orderId = or.Id });

    }
    public async Task<IActionResult> Grid_Update_Order(OrderModel o)
    {
        o.Date = DateTime.Now;
        o.OriginId = 1;
        await _orderService.Update(o);

        return Ok();

    }
    public async Task Grid_Delete_Order(int id) => await _orderService.Delete(id);

    // Order Detail
    public IActionResult OrderDetailView() => View("CrudOrdersDetail");
    public IActionResult OrderDetail(int orderId)
    {
        ViewData["order"] = new OrderModel { Id = orderId };
        return View("OrderDetail");
    }
    public async Task<IActionResult> Grid_Read_OrderDetail([DataSourceRequest] DataSourceRequest request, ProductModel p, int orderId)
    {
        var orderDetail = await _orderDetailService.GetAll(orderId);

        return Json(orderDetail.ToDataSourceResult(request));
    }

    public async Task<IActionResult> Grid_Create_OrderDetail(OrderDetailModel od, int orderId)
    {
        od.OrderId = orderId; od.ProductId = od.ProductItem.Id;
        return Json(await _orderDetailService.Add(od));
    }
    public async Task<IActionResult> Grid_Update_OrderDetail(OrderDetailModel od) => Json(await _orderDetailService.Update(od));
    public async Task Grid_Delete_OrderDetail(int id) => await _orderDetailService.Delete(id);
}
