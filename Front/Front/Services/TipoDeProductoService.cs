using Front.Interfaces;
using Front.Models;

namespace Front.Services;

public class TipoDeProductoService : ITipoDeProductoService
{

    private IHttpClientFactory _httpClientFactory;

    public TipoDeProductoService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<TipoDeProductoModels> Add(TipoDeProductoModels T)
    {
        var client = _httpClientFactory.CreateClient("Backend");

        var response = await client.PostAsJsonAsync<TipoDeProductoModels>(("/TipoDeProducto/"), T);

        return T;

    }

    public async Task Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("Backend");
        var response = await client.DeleteAsync(($"/TipoDeProducto/{id}"));
        Console.Write(response.StatusCode.ToString());


    }

    public async Task<TipoDeProductoModels> Edit(TipoDeProductoModels T)
    {
        var client = _httpClientFactory.CreateClient("Backend");

        var response = await client.PutAsJsonAsync<TipoDeProductoModels>(($"/TipoDeProducto/{T.id}"), T);

        return T;

    }

    public async Task<TipoDeProductoModels> Get(int id)
    {
        var client = _httpClientFactory.CreateClient("Backend");

        return await client.GetFromJsonAsync<TipoDeProductoModels>($"/TipoDeProducto/{id}");
    }

    public async Task<List<TipoDeProductoModels>> GetAll()
    {
        var client = _httpClientFactory.CreateClient("Backend");

        return await client.GetFromJsonAsync<List<TipoDeProductoModels>>("/TipoDeProducto/Listar");
    }
}
