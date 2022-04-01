using FrontEnd.Interfaces;
using FrontEnd.Models;

namespace FrontEnd.Services;
public class OriginService : IOriginService
{
    private IHttpClientFactory _httpClientFactory;
    public OriginService(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

    public async Task<List<OriginModel>> GetAll()
    {
        var client = _httpClientFactory.CreateClient("Backend");

        return await client.GetFromJsonAsync<List<OriginModel>>("Origin/List");
    }
    public async Task<OriginModel> Get(int id)
    {
        var client = _httpClientFactory.CreateClient("Backend");

        return await client.GetFromJsonAsync<OriginModel>($"Origin/{id}");
    }
    public async Task<OriginModel> Update(OriginModel originModel)
    {
        var client = _httpClientFactory.CreateClient("Backend");
        var response = await client.PutAsJsonAsync($"Origin/{originModel.Id}", originModel);
        if (((int)response.StatusCode) == 200)
        {

            //string cadena=(await response.Content.ReadAsStringAsync());   
            //var file = await response.Content.ReadAsStreamAsync(); 
            //ProductModel P = await response.Content.ReadFromJsonAsync<ProductModel>();

            return (await response.Content.ReadFromJsonAsync<OriginModel>());
        }

        throw new Exception();
    }
    public async Task Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("Backend");
        var res = await client.DeleteAsync($"Origin/{id}");
        string response = await res.Content.ReadAsStringAsync();
    }

    public async Task<OriginModel> Add(OriginModel originModel)
    {
        var client = _httpClientFactory.CreateClient("Backend");
        var response = await client.PostAsJsonAsync("Origin", originModel);

        return await response.Content.ReadFromJsonAsync<OriginModel>();
    }
}
