namespace WebAPI.Entities;

public class OrderDetail : TableBase
{
    public int Amount { get; set; }
    public Order Order { get; set; }
    public int OrderId { get; set; }
    public Product Product { get; set; }
    public int ProductId { get; set; }
}
