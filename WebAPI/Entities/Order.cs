namespace WebAPI.Entities;

public class Order
{
    public int Id { get; set; }
    public Origin Origin { get; set; }
    public int OriginId { get; set; }
    public DateTime Date { get; set; }
    public int State { get; set; }
    public Guid UserId { get; set; }
    public List<OrderDetail> orderDetails { get; set; }

}

