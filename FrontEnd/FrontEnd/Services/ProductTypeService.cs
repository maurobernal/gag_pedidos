using FrontEnd.Interfaces;
using FrontEnd.Models;

namespace FrontEnd.Services;
public class ProductTypeService : IProductTypeService
{
    private IHttpClientFactory _httpClientFactory;
    public ProductTypeService(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

    public Task<ProductTypeModel> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductTypeModel> Get(int id)
    {
        var client = _httpClientFactory.CreateClient("Backend");

        return await client.GetFromJsonAsync<ProductTypeModel>($"ProductType/{id}");
    }

    public async Task<List<ProductTypeModel>> GetAll()
    {
        var client = _httpClientFactory.CreateClient("Backend");

        return await client.GetFromJsonAsync<List<ProductTypeModel>>("ProductType/List");
    }

    public Task<ProductTypeModel> Update(ProductTypeModel productModel)
    {
        throw new NotImplementedException();
    }
}

