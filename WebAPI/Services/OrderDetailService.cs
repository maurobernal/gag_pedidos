using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTOs;
using WebAPI.Entities;
using WebAPI.InfraStructure;
using WebAPI.Interface;

namespace WebAPI.Services;
public class OrderDetailService : IOrderDetailService
{
    private readonly AppDBContext _conection;
    private readonly IMapper _mapper;

    public OrderDetailService(IMapper mapper)
    {
        _conection = new AppDBContext();
        _mapper = mapper;
    }
    public OrderDetailDTO AddOrderDetail(OrderDetailDTO orderDetail)
    {

        var O = _mapper.Map<OrderDetail>(orderDetail);
        O.Product = null;
        _conection.Add(O);
        _conection.SaveChanges();

        return _mapper.Map<OrderDetailDTO>(O);
    }

    public OrderDetailDTO UpdateOrderDetail(OrderDetailDTO orderDetail)
    {

        var entity = _conection.OrdersDetails.Where(o => o.id == orderDetail.Id).AsNoTracking().FirstOrDefault();
        if (entity == null) throw new Exception();

        entity = _mapper.Map<OrderDetail>(orderDetail);
        _conection.OrdersDetails.Update(entity);
        _conection.SaveChanges();

        return _mapper.Map<OrderDetailDTO>(entity);
    }

    public bool DeleteOrderDetail(int ID)
    {
        var entity = _conection.OrdersDetails.Where(o => o.id == ID).FirstOrDefault();
        if (entity == null) return false;

        _conection.OrdersDetails.Remove(entity);
        _conection.SaveChanges();

        return true;

    }

    public OrderDetailDTO GetOrderDetail(int ID) => _mapper.Map<OrderDetailDTO>(_conection.OrdersDetails.FirstOrDefault(o => o.id == ID));

    public List<OrderDetailDTO> GetAllOrdersDetails(int orderId)
    {

        //Entidad
        //var rmethod1 =
        // _conection.OrdersDetails.Include(c => c.Product)
        // .Where(p => p.OrderId == orderId)
        // .ToList();


        //Entidad OrderDetails  -- Select * from OrderDetailes p where p.Orderid=33
        //DTO
        //var rmethod2 = _conection.OrdersDetails.Include(c => c.Product)
        //    .Where(p => p.OrderId == orderId)
        //    .ProjectTo<OrderDetailDTO>(_mapper.ConfigurationProvider)
        //    .ToList();

        var rsyntax = (
                        from o in _conection.OrdersDetails
                        join p in _conection.Products on o.ProductId equals p.id


                        where o.OrderId == orderId
                        orderby o.Description
                        select new OrderDetailDTO
                        {
                            Id = o.id,
                            OrderId = o.OrderId,
                            ProductId = o.ProductId,
                            Description = o.Description,
                            Amount = o.Amount,
                            ProductItem = new ProductDTO { id = p.id, Description = p.Description, Active = p.Active, ProductTypeId = p.ProductTypeId },

                        }
                       ).ToList();


        return rsyntax;

    }

}
