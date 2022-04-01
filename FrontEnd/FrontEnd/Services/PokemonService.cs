using FrontEnd.Interfaces;
using FrontEnd.Models;

namespace FrontEnd.Services
{
    public class PokemonService : IPokemonService
    {
        private IHttpClientFactory _httpClientFactory;
        public PokemonService(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        public async Task<PokemonDetails> GetPokemonDetails(int ID)
        {
            var client = _httpClientFactory.CreateClient("PokeApi");

            return await client.GetFromJsonAsync<PokemonDetails>($"{ID}");
        }

        public async Task<List<PokemonModels>> GetPokemonList()
        {
            //HttpClient client1 = new HttpClient();
            //client1.Dispose();
            
            var client = _httpClientFactory.CreateClient("PokeApi");

            return (await client.GetFromJsonAsync<ResPokemonModels>("")).results;
                
        }
    }
}
