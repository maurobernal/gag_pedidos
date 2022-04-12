using FrontEnd.Interfaces;
using FrontEnd.Models;

namespace FrontEnd.Services;
public class OrderService : IOrderService
{
    private IHttpClientFactory _httpClientFactory;
    public OrderService(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

    public async Task<OrderModel> Add(OrderModel orderModel)
    {
        var client = _httpClientFactory.CreateClient("Backend");
        var response = await client.PostAsJsonAsync("Order", orderModel);

        return await response.Content.ReadFromJsonAsync<OrderModel>();
    }

    public async Task Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("Backend");
        var res = await client.DeleteAsync($"Order/{id}");
        string response = await res.Content.ReadAsStringAsync();
    }

    public async Task<OrderModel> Get(int id)
    {
        var client = _httpClientFactory.CreateClient("Backend");

        return await client.GetFromJsonAsync<OrderModel>($"Order/{id}");
    }

    public async Task<List<OrderModel>> GetAll()
    {
        var client = _httpClientFactory.CreateClient("Backend");

        return await client.GetFromJsonAsync<List<OrderModel>>("Order/List");
    }

    public async Task<OrderModel> Update(OrderModel orderModel)
    {
        var client = _httpClientFactory.CreateClient("Backend");
        var response = await client.PutAsJsonAsync($"Order/{orderModel.Id}", orderModel);

        if (((int)response.StatusCode) == 200)
        {
            return (await response.Content.ReadFromJsonAsync<OrderModel>());
        }

        throw new Exception();
    }

    public async Task<List<OrderModel>> GetAll(int option)
    {
        var client = _httpClientFactory.CreateClient("Backend");
        return await client.GetFromJsonAsync<List<OrderModel>>($"Order/List?option={option}");
    }
}
