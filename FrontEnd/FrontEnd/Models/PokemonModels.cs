namespace FrontEnd.Models;
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

public class Result
{
    public string name { get; set; }
    public string url { get; set; }
}

public class PokemonDetails
{
    public int id { get; set; }
    public int weight { get; set; }
    public int base_experience { get; set; }
}