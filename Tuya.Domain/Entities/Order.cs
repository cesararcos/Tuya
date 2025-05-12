namespace Tuya.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool State { get; set; }
        public Customer Customer { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new();
    }
}
