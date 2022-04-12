namespace WebAPI.DTOs;

public class OrderDTO
{
    public int Id { get; set; }
    public int OriginId { get; set; }
    public int State { get; set; }
    public DateTime Date { get; set; }

}
