using FrontEnd.Models;

namespace FrontEnd.Interfaces;
public interface IOrderDetailService
{
    public Task<List<OrderDetailModel>> GetAll(int orderId);
    public Task<OrderDetailModel> Get(int id);
    public Task<OrderDetailModel> Update(OrderDetailModel orderDetailModel);
    public Task Delete(int id);
    public Task<OrderDetailModel> Add(OrderDetailModel orderDetailModel);
}
