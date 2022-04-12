using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Interface;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderDetailController : Controller
{
    private IOrderDetailService _orderDetailService;

    public OrderDetailController(IOrderDetailService orderDetailService)
    {
        _orderDetailService = orderDetailService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] OrderDetailDTO orderDetail)
    {
        var res = _orderDetailService.AddOrderDetail(orderDetail);
        return Ok(res);
    }

    [HttpPut("{id}")]
    public IActionResult Update(OrderDetailDTO orderDetail, int id)
    {
        if (id != orderDetail.Id) return BadRequest();
        var res = _orderDetailService.UpdateOrderDetail(orderDetail);
        return Ok(res);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var res = _orderDetailService.DeleteOrderDetail(id);
        return Ok(res);
    }

    [HttpGet("{id}")]
    public IActionResult ListOne(int id)
    {
        var res = _orderDetailService.GetOrderDetail(id);
        if (res == null) return NotFound();
        return Ok(res);
    }

    [HttpGet("List")]
    public IActionResult ListAll(int orderId)
    {
        var res = _orderDetailService.GetAllOrdersDetails(orderId);
        return Ok(res);
    }
}