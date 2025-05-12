namespace Tuya.Domain.Entities;

public class Customer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Name { get; set; }
    public ICollection<Order> Orders { get; set; }
}
