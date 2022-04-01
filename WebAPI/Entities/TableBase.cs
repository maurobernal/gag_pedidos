namespace WebAPI.Entities;
public abstract class TableBase
{
    public int id { get; set; }
    public string Description { get; set; }
    public bool Active { get; set; }
}

