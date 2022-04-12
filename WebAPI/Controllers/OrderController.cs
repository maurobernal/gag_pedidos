using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Interface;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : Controller
{
    private IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] OrderDTO order)
    {
        var res = _orderService.AddOrder(order);
        return Ok(res);
    }

    [HttpPut("{id}")]
    public IActionResult Update(OrderDTO order, int id)
    {
        if (id != order.Id) return BadRequest();
        var res = _orderService.UpdateOrder(order);
        return Ok(res);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var res = _orderService.DeleteOrder(id);
        return Ok(res);
    }

    [HttpGet("{id}")]
    public IActionResult ListOne(int id)
    {
        var res = _orderService.GetOrder(id);
        if (res == null) return NotFound();
        return Ok(res);
    }

    [HttpGet("List")]
    public IActionResult ListAll(int option=0)
    {
        var res = _orderService.GetAllOrders(option);
        return Ok(res);
    }

    [HttpGet("ListOrders")]
    public IActionResult ListAll()
    {
        var res = _orderService.GetAllOrders();
        return Ok(res);
    }
}
