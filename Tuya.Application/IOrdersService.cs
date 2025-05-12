using Tuya.Application.DTOs;
using Tuya.Domain.Entities;

namespace Tuya.Application
{
    public interface IOrdersService
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Guid> CreateOrderAsync(OrderDto orderDto);
        Task<bool> CancelOrderAsync(Guid Id);
    }
}
