using WebAPI.DTOs;

namespace WebAPI.Interface;

public interface IOrderService
{
    OrderDTO AddOrder(OrderDTO order);
    bool DeleteOrder(int ID);
    List<OrderDTO> GetAllOrders();
    List<OrderDTO> GetAllOrders(int option);
    OrderDTO GetOrder(int ID);
    OrderDTO UpdateOrder(OrderDTO order);
}
