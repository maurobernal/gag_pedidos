using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTOs;
using WebAPI.Entities;
using WebAPI.InfraStructure;
using WebAPI.Interface;

namespace WebAPI.Services;
public class OrderService : IOrderService
{
    private readonly AppDBContext _conection;
    private readonly IMapper _mapper;

    public OrderService(IMapper mapper)
    {
        _conection = new AppDBContext();
        _mapper = mapper;
    }
    public OrderDTO AddOrder(OrderDTO order)
    {

        var O = _mapper.Map<Order>(order);
        O.State = 0;
        O.Date = DateTime.Now;
        O.OriginId = order.OriginId;

        _conection.Add(O);
        _conection.SaveChanges();

        return _mapper.Map<OrderDTO>(O);
    }

    public OrderDTO UpdateOrder(OrderDTO order)
    {

        var entity = _conection.Orders.Where(o => o.Id == order.Id).AsNoTracking().FirstOrDefault();
        if (entity == null) throw new Exception();

        entity = _mapper.Map<Order>(order);
        _conection.Orders.Update(entity);
        _conection.SaveChanges();

        return _mapper.Map<OrderDTO>(entity);
    }

    public bool DeleteOrder(int ID)
    {
        var entity = _conection.Orders.Where(o => o.Id == ID).FirstOrDefault();
        if (entity == null) return false;

        _conection.Orders.Remove(entity);
        _conection.SaveChanges();

        return true;
    }

    public OrderDTO GetOrder(int ID) => _mapper.Map<OrderDTO>(_conection.Orders.FirstOrDefault(o => o.Id == ID));


    public List<OrderDTO> GetAllOrders(int option)
    {
        List<Order> list = new List<Order>();

        list = _conection.Orders
            .Where(w => w.State == option)
            .ToList();
        return _mapper.Map<List<OrderDTO>>(list);
    }

    public List<OrderDTO> GetAllOrders() => _mapper.Map<List<OrderDTO>>(_conection.Orders.ToList());

}
