namespace WebApplication5.Models;

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; } // Navigation property for Order
    public int ProductId { get; set; }
    public Product Product { get; set; } // Navigation property for Product
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}

