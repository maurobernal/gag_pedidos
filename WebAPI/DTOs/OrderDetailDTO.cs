namespace WebAPI.DTOs;

public class OrderDetailDTO
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public string Description { get; set; }
    public ProductDTO? ProductItem { get; set; }

    public int Amount { get; set; }
}
