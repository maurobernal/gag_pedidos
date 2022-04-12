namespace WebAPI.Entities;

public class Product : TableBase
{
    public ProductType ProductType { get; set; }
    public int ProductTypeId { get; set; }
    public double Price { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
}
