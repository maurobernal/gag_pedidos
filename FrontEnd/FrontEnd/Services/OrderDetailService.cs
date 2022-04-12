using FrontEnd.Interfaces;
using FrontEnd.Models;

namespace FrontEnd.Services;
public class OrderDetailService : IOrderDetailService
{
    private IHttpClientFactory _httpClientFactory;
    public OrderDetailService(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

    public async Task<OrderDetailModel> Add(OrderDetailModel orderDetailModel)
    {
        var client = _httpClientFactory.CreateClient("Backend");
        var response = await client.PostAsJsonAsync("OrderDetail", orderDetailModel);

        return await response.Content.ReadFromJsonAsync<OrderDetailModel>();
    }

    public async Task Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("Backend");
        var res = await client.DeleteAsync($"OrderDetail/{id}");
        string response = await res.Content.ReadAsStringAsync();
    }

    public async Task<OrderDetailModel> Get(int id)
    {
        var client = _httpClientFactory.CreateClient("Backend");

        return await client.GetFromJsonAsync<OrderDetailModel>($"OrderDetail/{id}");
    }

    public async Task<List<OrderDetailModel>> GetAll(int orderId)
    {
        var client = _httpClientFactory.CreateClient("Backend");


        return await client.GetFromJsonAsync<List<OrderDetailModel>>($"OrderDetail/List?orderId={orderId}");
    }

    public async Task<OrderDetailModel> Update(OrderDetailModel orderDetailModel)
    {
        var client = _httpClientFactory.CreateClient("Backend");
        var response = await client.PutAsJsonAsync($"OrderDetail/{orderDetailModel.Id}", orderDetailModel);
        if (((int)response.StatusCode) == 200)
        {

            return (await response.Content.ReadFromJsonAsync<OrderDetailModel>());
        }

        throw new Exception();
    }
}
