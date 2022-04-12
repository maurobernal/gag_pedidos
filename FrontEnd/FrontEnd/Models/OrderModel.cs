namespace FrontEnd.Models;
public class OrderModel
{
    public int Id { get; set; }
    public int OriginId { get; set; }
    public DateTime Date { get; set; }
    public int State { get; set; }

}