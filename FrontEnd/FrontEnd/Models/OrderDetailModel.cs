using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models;
public class OrderDetailModel
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    [UIHint("ProductoEditor")]
    public ProductModel ProductItem { get; set; }
    public string Description { get; set; }
    public int Amount { get; set; }

}
