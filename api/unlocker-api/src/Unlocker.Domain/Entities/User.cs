namespace Unlocker.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Type { get; set; }
    public string Email { get; set; } = string.Empty;
    public string? GoogleId { get; set; }
    public string? SteamId { get; set; }
    public string Password { get; set; } = string.Empty;
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public List<Order> Orders { get; set; } = new();
}