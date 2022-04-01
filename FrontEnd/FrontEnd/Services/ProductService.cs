using FrontEnd.Interfaces;
using FrontEnd.Models;

namespace FrontEnd.Services;

public class ProductService : IProductService
{
    private IHttpClientFactory _httpClientFactory;
    public ProductService(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

    public async Task<List<ProductModel>> GetAll()
    {
        var client = _httpClientFactory.CreateClient("Backend");

        return await client.GetFromJsonAsync<List<ProductModel>>("Product/List");
    }
    public async Task<ProductModel> Get(int id)
    {
        var client = _httpClientFactory.CreateClient("Backend");

        return await client.GetFromJsonAsync<ProductModel>($"Product/{id}");
    }
    public async Task<ProductModel> Update(ProductModel productModel)
    {
        var client = _httpClientFactory.CreateClient("Backend");
        var response = await client.PutAsJsonAsync($"Product/{productModel.Id}", productModel);
        if (((int)response.StatusCode) == 200)
        {

            //string cadena=(await response.Content.ReadAsStringAsync());   
            //var file = await response.Content.ReadAsStreamAsync(); 
            //ProductModel P = await response.Content.ReadFromJsonAsync<ProductModel>();

            return (await response.Content.ReadFromJsonAsync<ProductModel>());
        }

        throw new Exception();
    }
    public async Task Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("Backend");
        var res = await client.DeleteAsync($"Product/{id}");
        string response = await res.Content.ReadAsStringAsync();
    }

    public async Task<ProductModel> Add(ProductModel productModel)
    {
        var client = _httpClientFactory.CreateClient("Backend");
        var response = await client.PostAsJsonAsync("Product", productModel);

        return await response.Content.ReadFromJsonAsync<ProductModel>();
    }

}
