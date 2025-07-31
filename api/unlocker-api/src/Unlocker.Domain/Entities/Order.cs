namespace Unlocker.Domain.Entities;

public class Order
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!; 
    public List<OrderItem> OrderItems { get; set; } = new();
}