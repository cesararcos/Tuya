using Tuya.Domain.Entities;

namespace Tuya.Domain
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task SaveAsync(Order order);
        Task<Order?> GetByIdAsync(Guid id);
    }
}
