namespace Filters_Middlewares.Models;

public class CreateOrderRequest
{
    public string Client { get; set; } = string.Empty;
    public int ProductId { get; set; }
    public int Amount { get; set; }
}
