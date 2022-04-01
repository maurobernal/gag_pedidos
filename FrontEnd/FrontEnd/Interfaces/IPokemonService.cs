using FrontEnd.Models;

namespace FrontEnd.Interfaces;

public interface IPokemonService
{
    public Task<List<PokemonModels>> GetPokemonList();
    public Task<PokemonDetails> GetPokemonDetails(int ID);
}

