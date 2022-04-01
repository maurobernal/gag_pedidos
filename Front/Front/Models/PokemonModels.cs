namespace Front.Models;

public class PokemonModels
{
    public string name { get; set; }

    public string url { get; set; }
}

public class ResPokemonModels
{
    public int count { get; set; }
    public string next { get; set; }
    public object previous { get; set; }
    public List<PokemonModels> results { get; set; }
}

public class PokemonDetails
{
    public int weigth { get; set; }

    public int id { get; set; }
}
