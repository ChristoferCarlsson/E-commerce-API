namespace WebApplication5.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } // Navigation property for User
    public List<OrderItem> OrderItems { get; set; } // Navigation property for OrderItems
}

