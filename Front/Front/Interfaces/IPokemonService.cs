using Front.Models;
namespace Front.Services;

public interface IPokemonService
{
    public Task<List<PokemonModels>> GetPokemonList();


    public Task<PokemonDetails> GetPokemonDetails(int id);

}
