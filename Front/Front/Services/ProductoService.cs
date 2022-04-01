using Front.Interfaces;
using Front.Models;

namespace Front.Services;

public class ProductoService : IProductoService
{
    private IHttpClientFactory _httpClientFactory;

    public ProductoService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<ProductoModels> Add(ProductoModels P)
    {
        var client = _httpClientFactory.CreateClient("Backend");

        var response = await client.PostAsJsonAsync<ProductoModels>(("/Producto/"), P);

        return P;

    }

    public async Task Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("Backend");
        var response = await client.DeleteAsync(($"/Producto/{id}"));
        Console.Write(response.StatusCode.ToString());


    }

    public async Task<ProductoModels> Edit(ProductoModels P)
    {
        var client = _httpClientFactory.CreateClient("Backend");

        var response = await client.PutAsJsonAsync<ProductoModels>(($"/Producto/{P.id}"), P);

        return P;

    }

    public async Task<ProductoModels> Get(int id)
    {
        var client = _httpClientFactory.CreateClient("Backend");

        return await client.GetFromJsonAsync<ProductoModels>($"/Producto/{id}");
    }

    public async Task<List<ProductoModels>> GetAll()
    {
        var client = _httpClientFactory.CreateClient("Backend");

        return await client.GetFromJsonAsync<List<ProductoModels>>("/Producto/Listar");
    }
}

