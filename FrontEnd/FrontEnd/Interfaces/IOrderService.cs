using FrontEnd.Models;

namespace FrontEnd.Interfaces;
public interface IOrderService
{
    public Task<List<OrderModel>> GetAll(int option);
    public Task<OrderModel> Get(int id);
    public Task<OrderModel> Update(OrderModel orderModel);
    public Task Delete(int id);
    public Task<OrderModel> Add(OrderModel orderModel);
}
