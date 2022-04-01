using Front.Models;

namespace Front.Services;

public class PokemonService : IPokemonService
{

    private IHttpClientFactory _httpClientFactory;

    public PokemonService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory; 
    }
   
    public async Task<PokemonDetails> GetPokemonDetails(int ID)
    {

        var client =   _httpClientFactory.CreateClient("PokeAPI");

        return await client.GetFromJsonAsync<PokemonDetails>($"{ID}");
    }

    public async Task<List<PokemonModels>> GetPokemonList()
    {

        var client = _httpClientFactory.CreateClient("PokeAPI");

        return (await client.GetFromJsonAsync<ResPokemonModels>("")).results;

        //List<PokemonModels> list = new List<PokemonModels>();
        //using (var client = new HttpClient())
        //{

        //      list = (await client.GetFromJsonAsync<ResPokemonModels>("https://pokeapi.co/api/v2/pokemon")).results;

        //    //var result2 = client.GetAsync("");
        //    //var result3 = client.GetAsync("");
        //    //var result4 = client.GetAsync("");

        //    //var res1 = await result1;
        //    //var res2 = await result2;
        //    //var res3 = result3.Result;
        //    //var res4 = result4.Result;
        //}


    }
}
