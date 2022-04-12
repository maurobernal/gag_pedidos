namespace WebAPI.DTOs;
public class ProductDTO
{
    public int id { get; set; }
    public string Description { get; set; }
    public bool Active { get; set; }
    public int ProductTypeId { get; set; }
}

