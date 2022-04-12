using WebAPI.DTOs;

namespace WebAPI.Interface;
public interface IOrderDetailService
{
    OrderDetailDTO AddOrderDetail(OrderDetailDTO orderDetail);
    public bool DeleteOrderDetail(int ID);
    List<OrderDetailDTO> GetAllOrdersDetails(int orderId);
    OrderDetailDTO GetOrderDetail(int ID);
    OrderDetailDTO UpdateOrderDetail(OrderDetailDTO orderDetail);

}
