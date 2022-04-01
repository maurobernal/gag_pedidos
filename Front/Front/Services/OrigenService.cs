using Front.Interfaces;
using Front.Models;
using System.Threading;

namespace Front.Services;

public class OrigenService : IOrigenService
{

    private IHttpClientFactory _httpClientFactory;

    public OrigenService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<OrigenModels> Add(OrigenModels O)
    {
       var client = _httpClientFactory.CreateClient("Backend");

       var response = await client.PostAsJsonAsync<OrigenModels>(("/Origen/"), O);

        return O;

    }

    public async Task Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("Backend");
        var response = await client.DeleteAsync(($"/Origen/{id}"));
        Console.Write(response.StatusCode.ToString());


    }

    public async Task<OrigenModels> Edit(OrigenModels O)
    {
        var client = _httpClientFactory.CreateClient("Backend");

        var response = await client.PutAsJsonAsync<OrigenModels>(($"/Origen/{O.id}"), O);

        return O;

    }

    public async Task<OrigenModels> Get(int id)
    {
        var client = _httpClientFactory.CreateClient("Backend");

        return await client.GetFromJsonAsync<OrigenModels>($"/Origen/{id}");
    }

    public async Task<List<OrigenModels>> GetAll()
    {
        var client = _httpClientFactory.CreateClient("Backend");

        return await client.GetFromJsonAsync<List<OrigenModels>>("/Origen/Listar");
    }
}
