using FrontEnd.Interfaces;
using FrontEnd.Models;

namespace FrontEnd.Services;
public class ProductTypeService : IProductTypeService
{
    private IHttpClientFactory _httpClientFactory;
    public ProductTypeService(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

    public async Task<ProductTypeModel> Add(ProductTypeModel productTypeModel)
    {
        var client = _httpClientFactory.CreateClient("Backend");
        var response = await client.PostAsJsonAsync("ProductType", productTypeModel);

        return await response.Content.ReadFromJsonAsync<ProductTypeModel>();
    }

    public async Task Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("Backend");
        var res = await client.DeleteAsync($"ProductType/{id}");
        string response = await res.Content.ReadAsStringAsync();
    }

    public async Task<ProductTypeModel> Get(int id)
    {
        var client = _httpClientFactory.CreateClient("Backend");

        return await client.GetFromJsonAsync<ProductTypeModel>($"ProductType/{id}");
    }

    public async Task<List<ProductTypeModel>> GetAll(string option)
    {
        var client = _httpClientFactory.CreateClient("Backend");

        return await client.GetFromJsonAsync<List<ProductTypeModel>>($"ProductType/List?option={option}");
    }

    public async Task<ProductTypeModel> Update(ProductTypeModel productTypeModel)
    {
        var client = _httpClientFactory.CreateClient("Backend");
        var response = await client.PutAsJsonAsync($"ProductType/{productTypeModel.Id}", productTypeModel);
        if (((int)response.StatusCode) == 200)
        {

            //string cadena=(await response.Content.ReadAsStringAsync());   
            //var file = await response.Content.ReadAsStreamAsync(); 
            //ProductModel P = await response.Content.ReadFromJsonAsync<ProductModel>();

            return (await response.Content.ReadFromJsonAsync<ProductTypeModel>());
        }

        throw new Exception();
    }
}

